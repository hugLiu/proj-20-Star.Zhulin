//获得Web路径---
function GetWebUrl(){
	var sCurFile;
	var sCurFile1;
	var sCurFile2;
	var sCurDir;
	
	sCurFile = document.URL;
//'去掉问号后面的部分--
	aCurFile1=sCurFile.split("?");
//'去掉文件名--
	aCurFile2=aCurFile1[0].split("/");
	
	sCurDir=""
	for ( var i=0;  i<aCurFile2.length-1; i++)
		sCurDir = sCurDir + aCurFile2[i] + "/" ;
	return (sCurDir);
}

//获取绝对路径
function canonical_uri(src, base_path) 
{ 
	var root_page = /^[^?#]*\//.exec(location.href)[0], 
	root_domain = /^\w+\:\/\/\/?[^\/]+/.exec(root_page)[0], 
	absolute_regex = /^\w+\:\/\//; 

	// is `src` is protocol-relative (begins with // or ///), prepend protocol 
	if (/^\/\/\/?/.test(src)) 
	{ 
	src = location.protocol + src; 
	} 
	// is `src` page-relative? (not an absolute URL, and not a domain-relative path, beginning with /) 
	else if (!absolute_regex.test(src) && src.charAt(0) != "/") 
	{ 
	// prepend `base_path`, if any 
	src = (base_path || "") + src; 
	} 

	// make sure to return `src` as absolute 
	return absolute_regex.test(src) ? src : ((src.charAt(0) == "/" ? root_domain : root_page) + src); 
}

//正则表达式replace
String.prototype.replaceAll = function (s1, s2) {
    var r = new RegExp(s1.replace(/([\(\)\[\]\{\}\^\$\+\-\*\?\.\"\'\|\/\\])/g, "\\$1"), "ig");
    return this.replace(r, s2);
}

//getQueryString
function getQueryString(name) {
	var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)", "i");
	var r = window.location.search.substr(1).match(reg);
	if (r != null) return unescape(r[2]);
	return null;
}

//字符串形式
function getUrlRequest(url) {
	var prams = url.substr(url.indexOf("?"));//获取url中“?”字符后的字符串

	var theReq = new Object();
	if (prams.indexOf("?") != -1)
	{
		var str = prams.substr(1);
		var strs = str.split("&");
		var keyvalue;
		for (var i=0; i<strs.length; i++)
		{
			keyvalue = strs[i].split("=");
			theReq[keyvalue[0]] = keyvalue[1];
		}
	}
	return theReq;
}

function fixOcxMask(container) {
	var frame = $("<iframe frameborder=0 scrolling=no style='background-color:transparent; position: absolute; z-index: -1; width: 100%; height: 100%; top: 0;left:0;'></iframe>");
	$(container).append(frame);
}

function InitActiveX(AcitveXObjectID,ContianerID){
	var ce = document.getElementById(ContianerID);
	var ac = document.createElement("Object");
	if (ce)
	{
		ac.id="joGIS1";
		ac.classid="clsid:D2546426-13FD-4018-85F1-F5BD61147C8F";
		ac.CODEBASE="JoGIS4.ocx#version=1,0,0,1";
		ac.style.width = "100%";
		ac.style.height = "500px";
		ac.wmode="Opaque";

	    ce.appendChild(ac);
	}

}

//@AcitveXObjectID: 要删除的ActiveX控件ID。
//@ContianerID: 要查找的节点范围，从此节点一下查找待删除的ActiveX。
function ActiveXKiller(AcitveXObjectID,ContianerID){   
	var ce = document.getElementById(ContianerID);
	if (ce)
	{
	    var cce = ce.children;
	    for (var i = 0; i < cce.length; i = i + 1)
	    {
	        if (cce[i].id == AcitveXObjectID)
	        {
	            ce.removeChild(cce[i]);
	        }
	    }
	}

}

var OpenResultWin = function(resultid) {
	//window.open
}