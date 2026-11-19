#include <stdio.h>
#include <dirent.h>

extern int ubidi_countRuns(void* pBiDi, int* errorCode);
extern unsigned char uscript_nextRun(void* scriptRun, int* pRunStart, int* pRunLimit, int* pRunScript);
extern void* uscript_openRun(short int* text, int length, int* pErrorCode);
extern void* ubidi_openSized(int maxLenght, int maxRunCount, int* pErrorCode);
extern void ubidi_setPara(void* pBiDi, short int* text, int length, int paraLevel, int* embeddingLevels, int* pErrorCode);
extern void ubidi_close(void* pBiDi);
extern int ubidi_getParaLevel(void* pBiDi);
extern int ubidi_getDirection(void* pBiDi);
extern int ubidi_getVisualRun(void* pBiDi, int runIndex, int* pLogicalStart, int* pLength);
extern void uscript_closeRun(void* scriptRun);
extern void* uscript_getShortName(int script);
extern void ubidi_getLogicalRun(void* pBiDi, int startPosition, int* endPosition, int* runLevel);
extern int uscript_getScript(int ch, int* param1);
extern void* ubrk_open(int uBreakIteratorType, void* locale, short int* text, int length, int* errorCode);
extern void ubrk_close(void* bi);
extern int ubrk_next(void* bi);
extern int ubrk_getRuleStatus(void* bi);


int ubidi_countRuns_wrapper(void* pBiDi, int* errorCode) {
 return ubidi_countRuns(pBiDi, errorCode);
}
unsigned char uscript_nextRun_wrapper(void* scriptRun, int* pRunStart, int* pRunLimit, int* pRunScript) {
 return uscript_nextRun(scriptRun, pRunStart, pRunLimit, pRunScript);
}
void* uscript_openRun_wrapper(short int* text, int length, int* pErrorCode) {
 return uscript_openRun(text, length, pErrorCode);
}
void* ubidi_openSized_wrapper(int maxLenght, int maxRunCount, int* pErrorCode) {
 return ubidi_openSized(maxLenght, maxRunCount, pErrorCode);
}
void ubidi_setPara_wrapper(void* pBiDi, short int* text, int length, int paraLevel, int* embeddingLevels, int* pErrorCode) {
 ubidi_setPara(pBiDi, text, length, paraLevel, embeddingLevels, pErrorCode);
}
void ubidi_close_wrapper(void* pBiDi) {
 ubidi_close(pBiDi);
}
int ubidi_getParaLevel_wrapper(void* pBiDi) {
 return ubidi_getParaLevel(pBiDi);
}
int ubidi_getDirection_wrapper(void* pBiDi) {
 return ubidi_getDirection(pBiDi);
}
int ubidi_getVisualRun_wrapper(void* pBiDi, int runIndex, int* pLogicalStart, int* pLength) {
 return ubidi_getVisualRun(pBiDi, runIndex, pLogicalStart, pLength);
}
void uscript_closeRun_wrapper(void* scriptRun) {
 uscript_closeRun(scriptRun);
}
void* uscript_getShortName_wrapper(int script) {
 return uscript_getShortName(script);
}
void ubidi_getLogicalRun_wrapper(void* pBiDi, int startPosition, int* endPosition, int* runLevel) {
 ubidi_getLogicalRun(pBiDi, startPosition, endPosition, runLevel);
}
int uscript_getScript_wrapper(int ch, int* param1) {
 return uscript_getScript(ch, param1);
}
void* ubrk_open_wrapper(int uBreakIteratorType, void* locale, short int* text, int length, int* errorCode) {
 return ubrk_open(uBreakIteratorType, locale, text, length, errorCode);
}
void ubrk_close_wrapper(void* bi) {
 ubrk_close(bi);
}
int ubrk_next_wrapper(void* bi) {
 return ubrk_next(bi);
}
int ubrk_getRuleStatus_wrapper(void* bi) {
 return ubrk_getRuleStatus(bi);
}