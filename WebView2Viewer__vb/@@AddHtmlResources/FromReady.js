window.focus();


const _ET_FOCUS = 'focus';
const _ET_CLICK = 'click';
const _ET_GET_HTML_TEXT = 'getHtmlText';


window.addEventListener(_ET_FOCUS, (e) => {
	try {
		//console.log('처음에 왜 두번이나 호출이 되어버릴까?', e.type, e);
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
	//console.log("호출이 된것입니까?, ", bodyHtml);

	const htmlText = document.documentElement.outerHTML;
	//console.log("호출이 된것입니까?, ", htmlText);

	chrome.webview.postMessage({ type: _ET_GET_HTML_TEXT, dump: htmlText });
	//return htmlText;
};
