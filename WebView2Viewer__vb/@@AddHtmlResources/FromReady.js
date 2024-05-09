window.focus();
window.addEventListener('focus', (e) => {
	try {
		//console.log('=================================================');
		//console.log('처음에 왜 두번이나 호출이 되어버릴까?', e.type, e);
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
		
		//console.log('처음에 왜 두번이나 호출이 되어버릴까?', e.type, e);
		
		console.log('>>> 1');
	}
	catch {		
		console.log('>>> 2');
	}
	finally {		
		console.log('>>> 3');
	}
});