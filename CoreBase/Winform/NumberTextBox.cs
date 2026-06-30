using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CoreBase.Winform
{
    /// <summary>
    /// 純數值的輸入框
    /// </summary>
    [Description("純數值輸入框")]
    public class NumberTextBox : TextBox
    {
        // 數字 Regex 的 Pattern
        private string _Pattern = "^\\d{0,10}(\\.?)(\\d{0,2})$";
        [Category("數字限制")]
        [Description("正則表達式規則")]
        public string Pattern
        {
            get { return _Pattern; }
            set
            {
                if (_DecimalPlace > 0)
                {
                    _Pattern = "^\\d{0," + _IntegerDigits + "}(\\.?)(\\d{0," + _DecimalPlace + "})$";
                }
                else
                {
                    _Pattern = "^\\d{0," + _IntegerDigits + "}";
                }

                if (string.IsNullOrWhiteSpace(value) == false)
                {
                    _Pattern = value;
                }
            }
        }

        // 最大值        
        private decimal _Max = 9999999999;
        [Category("數字限制")]
        [Description("最大值")]
        public decimal Max
        {
            get { return _Max; }
            set { _Max = value; }
        }

        // 最小值
        private decimal _Min = 0;
        [Category("數字限制")]
        [Description("最小值")]
        public decimal Min
        {
            get { return _Min; }
            set { _Min = value; }
        }

        // 小數位數
        private int _DecimalPlace = 0;
        [Category("數字限制")]
        [Description("小數位數")]
        public int DecimalPlace
        {
            get { return _DecimalPlace; }
            set { _DecimalPlace = value; }
        }

        // 整數位數
        private int _IntegerDigits = 10;
        [Category("數字限制")]
        [Description("整數位數")]
        [DefaultValue(10)]
        public int IntegerDigits
        {
            get { return _IntegerDigits; }
            set { _DecimalPlace = value; }
        }

        // 數字長度
        [Category("數字限制")]
        [Description("數字長度，有小數時，含小數點")]
        [DefaultValue(10)]
        protected new int MaxLength
        {
            get { return base.MaxLength; }
            set { base.MaxLength = value; }
        }

        // 鎖定輸入法切換
        [Browsable(false)] // 隱藏選項
        protected override ImeMode DefaultImeMode
        {
            get { return ImeMode.Disable; }
        }

        /// <summary>
        /// 按鍵按下時的判斷
        /// </summary>
        /// <param name="e"></param>
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            e.Handled = true;
            var NumberVaild = new Regex(Pattern);
            //if (NumberVaild.IsMatch(e.KeyChar.ToString())
            if (new Regex("[0-9|.]").IsMatch(e.KeyChar.ToString())
                || char.IsControl(e.KeyChar))
            {
                // 已有一個小數點時，再輸入的小數點不予作用
                if (base.Text.Contains(".") && e.KeyChar.ToString() == ".")
                {
                    e.Handled = true;
                }
                else if (NumberVaild.IsMatch(base.Text ?? string.Empty) == false)
                {
                    e.Handled = true;
                }
                else
                {
                    e.Handled = false;
                }
            }
            else
            {
                e.Handled = true;
            }

            base.OnKeyPress(e);
        }

        /// <summary>
        /// 按鍵放開時的判斷
        /// </summary>
        /// <param name="e"></param>
        protected override void OnKeyUp(KeyEventArgs e)
        {
            e.Handled = true;

            var NumberVaild = new Regex(Pattern);

            if (NumberVaild.IsMatch(base.Text ?? string.Empty) == false)
            {
                // 無法轉換成數值的，清空輸入
                if (decimal.TryParse(base.Text, out decimal result) == false)
                {
                    base.Text = string.Empty;
                }
                else
                {
                    // 不符合規範的輸入則移除輸入
                    var selectionStart = base.SelectionStart - 1;
                    base.Text = base.Text.Remove(selectionStart, 1);
                    base.SelectionStart = selectionStart;
                }
            }

            base.OnKeyUp(e);
        }
    }
}
