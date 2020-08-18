#include <MsgBoxConstants.au3>
Example()
Func Example()

	If WinExists("LoginWebView", "") Then
		WinWait("LoginWebView", "", 2)
		WinActivate("LoginWebView")
		;Sleep(4000)
		Send("guilt")
		Sleep(4000)
		Send("{TAB}")
		;Usually checks a checkbox (if it's a "real" checkbox.)
		Send("{+}")
		sleep(4000)
		Send("{TAB}")
		Send("{ENTER}")
	Else
		; Dont do anything
	EndIf
EndFunc
