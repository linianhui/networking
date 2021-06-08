using System.IO;
using Networking.Display.Text;

namespace Networking.Display
{
    /// <summary>
    /// <see cref="IDisplayer"/>工厂
    /// </summary>
    public static class DisplayerFactory
    {
        private static readonly DisplayDispatcher TextDisplayDispatcher = new DisplayDispatcher(typeof(TextDisplayer));

        /// <summary>
        /// 创建
        /// </summary>
        public static IDisplayer Text(TextWriter textWriter)
        {
            return new TextDisplayer(textWriter, TextDisplayDispatcher);
        }
    }
}
