window.focus();


const _ET_FOCUS = 'focus';
const _ET_CLICK = 'click';
const _ET_GET_HTML_TEXT = 'getHtmlText';


window.addEventListener(_ET_FOCUS, (e) => {
	try {
		//console.log('ó���� �� �ι��̳� ȣ���� �Ǿ������?', e.type, e);
		chrome.webview.postMessage({type: e.type, dump: null});
	}
	catch { } 
	finally { }
});


//window.addEventListener(_ET_CLICK, (e) => {
//	try {
//		//const bodyHtml = document.body.innerHTML;
//		//chrome.webview.postMessage({type: e.type, dump: bodyHtml});
//	}
//	catch { }
//	finally { }
//});


const fn_getHtmlText = () => {
	//const bodyHtml = document.body.innerHTML;
	//console.log("ȣ���� �Ȱ��Դϱ�?, ", bodyHtml);

	const htmlText = document.documentElement.outerHTML;
	//console.log("ȣ���� �Ȱ��Դϱ�?, ", htmlText);

	chrome.webview.postMessage({ type: _ET_GET_HTML_TEXT, dump: htmlText });
	//return htmlText;
};
