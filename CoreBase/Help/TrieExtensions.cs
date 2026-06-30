using System;
using System.Collections.Generic;
using System.Linq;

namespace CoreBase.Help
{
    /// <summary>
    /// Trie Extension
    /// </summary>
    public static class TrieExtensions
    {
        #region PrefixTree Tire  高效支援搜尋
        /*
           //使用範例
           var trie = new PrefixTree<string>(ignoreCase: true);
           trie.Insert("Apple", "A1");
           trie.Insert("AppStore", "A2");
           trie.Insert("Application", "A3");
           trie.Insert("Orange", "O1");
           
           // 是否存在完整 key？
           Console.WriteLine(trie.Contains("AppStore")); // true
           
           // 試著取得值
           if (trie.TryGet("apple", out var val))
               Console.WriteLine($"Found: {val}");
           
           // 取得前綴所有符合的項目
           var prefixList = trie.FindByPrefix("app");
           foreach (var (k, v) in prefixList)
               Console.WriteLine($"{k} => {v}");
           
           // 計算前綴項目總數
           Console.WriteLine("app count = " + trie.CountPrefix("app"));
           
           // 模糊查詢（可容忍 2 個錯字）
           var fuzzy = trie.StartsWithFuzzy("applz", 2);
           foreach (var (k, v) in fuzzy)
               Console.WriteLine($"Fuzzy match: {k} => {v}");
         */
        /// <summary>
        /// 高效搜尋 PreFixTree TireMode
        /// </summary>
        /// <typeparam name="T">Model</typeparam>
        public class PrefixTree<T>
        {
            /// <summary>
            /// Trie Node
            /// </summary>
            private class TrieNode
            {
                /// <summary>
                /// 子類
                /// </summary>
                public Dictionary<char, TrieNode> Children = new();
                /// <summary>
                /// 是否結尾
                /// </summary>
                public bool IsEnd = false;
                /// <summary>
                /// Model
                /// </summary>
                public T Value;
            }
            /// <summary>
            /// 根
            /// </summary>
            private readonly TrieNode _root = new();
            /// <summary>
            /// 是否忽略大小寫
            /// </summary>
            private readonly bool _ignoreCase;
            /// <summary>
            /// 初始化
            /// </summary>
            /// <param name="ignoreCase">是否忽略大小寫?，True:統一轉成小寫進行運算,False:區分大小寫進行運算;[預設False]</param>
            public PrefixTree(bool ignoreCase = false)
            {
                _ignoreCase = ignoreCase;
            }
            /// <summary>
            /// 統一轉換字串成比對用的標準格式
            /// </summary>
            /// <param name="key"></param>
            /// <returns></returns>
            private string Normalize(string key) => _ignoreCase ? key.ToLowerInvariant() : key;
            /// <summary>
            /// 新增節點
            /// </summary>
            /// <param name="key"></param>
            /// <param name="value"></param>
            public void Insert(string key, T value)
            {
                key = Normalize(key);
                var node = _root;
                foreach (char c in key)
                {
                    if (!node.Children.ContainsKey(c))
                        node.Children[c] = new TrieNode();
                    node = node.Children[c];
                }

                node.IsEnd = true;
                node.Value = value;
            }
            /// <summary>
            /// 是否包含
            /// </summary>
            /// <param name="key"></param>
            /// <returns></returns>
            public bool Contains(string key)
            {
                key = Normalize(key);
                var node = _root;
                foreach (char c in key)
                {
                    if (!node.Children.TryGetValue(c, out node))
                        return false;
                }
                return node.IsEnd;
            }
            /// <summary>
            /// 嘗試取得數值
            /// </summary>
            /// <param name="key">搜尋關鍵字</param>
            /// <param name="value">輸出Model</param>
            /// <returns></returns>
            public bool TryGet(string key, out T value)
            {
                key = Normalize(key);
                var node = _root;
                foreach (char c in key)
                {
                    if (!node.Children.TryGetValue(c, out node))
                    {
                        value = default!;
                        return false;
                    }
                }

                if (node.IsEnd)
                {
                    value = node.Value;
                    return true;
                }

                value = default!;
                return false;
            }
            /// <summary>
            /// 計算前綴項目總數
            /// </summary>
            /// <param name="prefix"></param>
            /// <returns></returns>
            public int CountPrefix(string prefix)
            {
                prefix = Normalize(prefix);
                var node = _root;

                foreach (char c in prefix)
                {
                    if (!node.Children.TryGetValue(c, out node))
                        return 0;
                }

                return DFSCount(node);
            }
            /// <summary>
            /// 取得前綴所有符合的項目
            /// </summary>
            /// <param name="prefix"></param>
            /// <returns></returns>
            public List<(string Key, T Value)> FindByPrefix(string prefix)
            {
                prefix = Normalize(prefix);
                var result = new List<(string, T)>();
                var node = _root;

                foreach (char c in prefix)
                {
                    if (!node.Children.TryGetValue(c, out node))
                        return result;
                }

                DFS(node, prefix, result);
                return result;
            }

            // --- 私有輔助 ---
            private int DFSCount(TrieNode node)
            {
                int count = node.IsEnd ? 1 : 0;
                foreach (var child in node.Children.Values)
                    count += DFSCount(child);
                return count;
            }
            /// <summary>
            /// DFS = Depth-First-Search 
            /// 找出所有以某個前綴開頭的 key + value 資料
            /// </summary>
            /// <param name="node"></param>
            /// <param name="prefix"></param>
            /// <param name="result"></param>
            private void DFS(TrieNode node, string prefix, List<(string, T)> result)
            {
                if (node.IsEnd)
                    result.Add((prefix, node.Value));

                foreach (var kvp in node.Children)
                    DFS(kvp.Value, prefix + kvp.Key, result);
            }

            // --- 可選功能：模糊搜尋 ---
            /// <summary>
            /// 模糊查詢（可容忍 maxDistance 個錯字）
            /// </summary>
            /// <param name="input"></param>
            /// <param name="maxDistance"></param>
            /// <returns></returns>
            public List<(string Key, T Value)> StartsWithFuzzy(string input, int maxDistance)
            {
                List<(string key, T value)> allResults = new List<(string, T)>();
                DFS(_root, "", allResults);

                return allResults
                    .Where(item => Levenshtein(item.key, input) <= maxDistance)
                    .ToList();
            }

            // Levenshtein 距離計算
            /// <summary>
            /// Levenshtein 距離計算
            /// </summary>
            /// <param name="s"></param>
            /// <param name="t"></param>
            /// <returns></returns>
            private int Levenshtein(string s, string t)
            {
                int n = s.Length, m = t.Length;
                int[,] d = new int[n + 1, m + 1];

                for (int i = 0; i <= n; i++) d[i, 0] = i;
                for (int j = 0; j <= m; j++) d[0, j] = j;

                for (int i = 1; i <= n; i++)
                {
                    for (int j = 1; j <= m; j++)
                    {
                        int cost = s[i - 1] == t[j - 1] ? 0 : 1;
                        d[i, j] = Math.Min(
                            Math.Min(d[i - 1, j] + 1, d[i, j - 1] + 1),
                            d[i - 1, j - 1] + cost);
                    }
                }

                return d[n, m];
            }
        }

        #endregion
        /// <summary>
        /// 載入Dictionary
        /// </summary>
        /// <typeparam name="T">Model</typeparam>
        /// <param name="trie">Trie Class</param>
        /// <param name="source">Dictionary&lt;string, T&gt;</param>
        public static void LoadFromDictioanry<T>(this PrefixTree<T> trie, Dictionary<string, T> source)
        {
            foreach (var kv in source)
            {
                trie.Insert(kv.Key, kv.Value);
            }
        }
    }
}
