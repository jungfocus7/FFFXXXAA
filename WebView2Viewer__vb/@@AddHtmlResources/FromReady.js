window.focus();
window.addEventListener('focus', (e) => {
	try {
		//console.log('ó���� �� �ι��̳� ȣ���� �Ǿ������?', e.type, e);
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