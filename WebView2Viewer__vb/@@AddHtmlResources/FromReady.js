window.focus();
window.addEventListener('focus', (e) => {
	try {
		//console.log('처음에 왜 두번이나 호출이 되어버릴까?', e.type, e);
		chrome.webview.postMessage(`${e.type}|empty`);
	} catch { }
});