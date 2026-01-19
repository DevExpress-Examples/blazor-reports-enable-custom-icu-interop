using System.Runtime.InteropServices;
using DevExpress.Drawing.Internal.Fonts.Interop;
namespace BlazorWasmCustomIcuInteropExample.Client.Native {
    public class IcuInterop : ICustomICUInterop {

        [DllImport("wrapper")]
        static extern int ubidi_countRuns_wrapper(IntPtr pBiDi, out UErrorCode errorCode);

        [DllImport("wrapper")]
        static extern byte uscript_nextRun_wrapper(IntPtr scriptRun, out int pRunStart, out int pRunLimit, out UScriptCode pRunScript);

        [DllImport("wrapper")]
        static extern IntPtr uscript_openRun_wrapper(string text, int length, out UErrorCode pErrorCode);

        [DllImport("wrapper")]
        static extern IntPtr ubidi_openSized_wrapper(int maxLenght, int maxRunCount, out UErrorCode pErrorCode);

        [DllImport("wrapper")]
        static extern void ubidi_setPara_wrapper(IntPtr pBiDi, string text, int length, UBiDiLevel paraLevel, UBiDiLevel[] embeddingLevels, out UErrorCode pErrorCode);

        [DllImport("wrapper")]
        static extern void ubidi_close_wrapper(IntPtr pBiDi);

        [DllImport("wrapper")]
        static extern UBiDiLevel ubidi_getParaLevel_wrapper(IntPtr pBiDi);

        [DllImport("wrapper")]
        static extern UBiDiDirection ubidi_getDirection_wrapper(IntPtr pBiDi);

        [DllImport("wrapper")]
        static extern UBiDiDirection ubidi_getVisualRun_wrapper(IntPtr pBiDi, int runIndex, out int pLogicalStart, out int pLength);

        [DllImport("wrapper")]
        static extern void uscript_closeRun_wrapper(IntPtr scriptRun);

        [DllImport("wrapper")]
        static extern IntPtr uscript_getShortName_wrapper(UScriptCode script);

        [DllImport("wrapper")]
        static extern void ubidi_getLogicalRun_wrapper(IntPtr pBiDi, int startPosition, out int endPosition, out UBiDiLevel runLevel);

        [DllImport("wrapper")]
        static extern UScriptCode uscript_getScript_wrapper(int ch, out UErrorCode param1);

        [DllImport("wrapper")]
        static extern IntPtr ubrk_open_wrapper(UBreakIteratorType uBreakIteratorType, IntPtr locale, string text, int length, out UErrorCode errorCode);

        [DllImport("wrapper")]
        static extern void ubrk_close_wrapper(IntPtr bi);

        [DllImport("wrapper")]
        static extern int ubrk_next_wrapper(IntPtr bi);

        [DllImport("wrapper")]
        static extern int ubrk_getRuleStatus_wrapper(IntPtr bi);

        public int UBiDiCountRuns(IntPtr pBiDi, out UErrorCode errorCode) {
            return ubidi_countRuns_wrapper(pBiDi, out errorCode);
        }
        public byte UScriptNextRun(IntPtr scriptRun, out int pRunStart, out int pRunLimit, out UScriptCode pRunScript) {
            return uscript_nextRun_wrapper(scriptRun, out pRunStart, out pRunLimit, out pRunScript);
        }
        public IntPtr UScriptOpenRun(string text, int length, out UErrorCode pErrorCode) {
            return uscript_openRun_wrapper(text, length, out pErrorCode);
        }
        public IntPtr UBiDiOpenSized(int maxLenght, int maxRunCount, out UErrorCode pErrorCode) {
            return ubidi_openSized_wrapper(maxLenght, maxRunCount, out pErrorCode);
        }
        public void UBiDiSetPara(IntPtr pBiDi, string text, int length, UBiDiLevel paraLevel, UBiDiLevel[] embeddingLevels, out UErrorCode pErrorCode) {
            ubidi_setPara_wrapper(pBiDi, text, length, paraLevel, embeddingLevels, out pErrorCode);
        }
        public void UBiDiClose(IntPtr pBiDi) {
            ubidi_close_wrapper(pBiDi);
        }
        public UBiDiLevel UBiDiGetParaLevel(IntPtr pBiDi) {
            return ubidi_getParaLevel_wrapper(pBiDi);
        }
        public UBiDiDirection UBiDiGetDirection(IntPtr pBiDi) {
            return ubidi_getDirection_wrapper(pBiDi);
        }
        public UBiDiDirection UBiDiGetVisualRun(IntPtr pBiDi, int runIndex, out int pLogicalStart, out int pLength) {
            return ubidi_getVisualRun_wrapper(pBiDi, runIndex, out pLogicalStart, out pLength);
        }
        public void UScriptCloseRun(IntPtr scriptRun) {
            uscript_closeRun_wrapper(scriptRun);
        }
        public IntPtr UScriptGetShortName(UScriptCode script) {
            return uscript_getShortName_wrapper(script);
        }
        public void UBiDiGetLogicalRun(IntPtr pBiDi, int startPosition, out int endPosition, out UBiDiLevel runLevel) {
            ubidi_getLogicalRun_wrapper(pBiDi, startPosition, out endPosition, out runLevel);
        }
        public UScriptCode UScriptGetScript(int ch, out UErrorCode param1) {
            return uscript_getScript_wrapper(ch, out param1);
        }
        public IntPtr UBrkOpen(UBreakIteratorType uBreakIteratorType, IntPtr locale, string text, int length, out UErrorCode errorCode) {
            return ubrk_open_wrapper(uBreakIteratorType, locale, text, length, out errorCode);
        }
        public void UBrkClose(IntPtr bi) {
            ubrk_close_wrapper(bi);
        }
        public int UBrkNext(IntPtr bi) {
            return ubrk_next_wrapper(bi);
        }
        public int UBrkGetRuleStatus(IntPtr bi) {
            return ubrk_getRuleStatus_wrapper(bi);
        }
    }
}
