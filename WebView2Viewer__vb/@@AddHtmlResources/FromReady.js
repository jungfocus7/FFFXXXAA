window.focus();
window.addEventListener('focus', (e) => {
	try {
		//console.log('ó���� �� �ι��̳� ȣ���� �Ǿ������?', e.type, e);
		chrome.webview.postMessage(`${e.type}|empty`);
	} catch { }
});