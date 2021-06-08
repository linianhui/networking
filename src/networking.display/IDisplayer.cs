using System;

namespace Networking.Display
{
    /// <summary>
    /// 显示器
    /// </summary>
    public interface IDisplayer
    {
        /// <summary>
        /// 新行
        /// </summary>
        void NewLine(String message = "");

        /// <summary>
        /// 显示
        /// </summary>
        void Display(Octets octets);
    }
}
