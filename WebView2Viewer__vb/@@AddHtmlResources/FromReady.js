window.focus();
window.addEventListener('focus', (e) => {
	try {
		//console.log('=================================================');
		//console.log('ó���� �� �ι��̳� ȣ���� �Ǿ������?', e.type, e);
		chrome.webview.postMessage({type: e.type, dump: null});
	}
	catch { }
	finally { }
});

window.addEventListener('click', (e) => {
	try {
		console.log('=================================================');
		const bodyHtml = document.body.innerHTML;
		//console.log('>>> ', bodyHtml);
		chrome.webview.postMessage({type: e.type, dump: bodyHtml});
		
		//console.log('ó���� �� �ι��̳� ȣ���� �Ǿ������?', e.type, e);
		
		console.log('>>> 1');
	}
	catch {		
		console.log('>>> 2');
	}
	finally {		
		console.log('>>> 3');
	}
});