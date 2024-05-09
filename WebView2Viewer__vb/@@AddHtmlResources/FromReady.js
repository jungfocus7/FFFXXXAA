window.focus();
window.addEventListener('focus', (e) => {
	try {
		//console.log('처음에 왜 두번이나 호출이 되어버릴까?', e.type, e);
		chrome.webview.postMessage({type: e.type, dump: null});
	}
	catch { }
	finally { }
});

window.addEventListener('click', (e) => {
	try {
		//const bodyHtml = document.body.innerHTML;
		//chrome.webview.postMessage({type: e.type, dump: bodyHtml});
	}
	catch { }
	finally { }
});