var canvas = document.getElementById("myCanvas");
var imageUrlInput = document.getElementById("imageUrl");
var fileInputItem = document.getElementById("fileInputItem");
var downloadLnkItem = document.getElementById("downloadLnk");

var saveButttonItem = document.getElementById("saveButtton");
var cancelAllButttonItem = document.getElementById("canselAllButtton");
var imageActionDivItem = document.getElementById("imageActionDiv");

var changeSizeDiv = document.getElementById("changeSizeDiv");
var changeSizeBtn = document.getElementById("changeSizeBtn");
var changeSizeW = document.getElementById("changeSizeW");
var changeSizeH = document.getElementById("changeSizeH");

var blurFilterButton = document.getElementById("blurFilter");
var brightnessFilterButton = document.getElementById("brightnessFilter");
var notBrightnessFilterButton = document.getElementById("notBrightnessFilter");
var contrastFilterButton = document.getElementById("contrastFilter");
var shadowFilterButton = document.getElementById("shadowFilter");
var grayscaleFilterButton = document.getElementById("grayscaleFilter");

var hueRotate1FilterButton = document.getElementById("hueRotate1Filter");
var hueRotate2FilterButton = document.getElementById("hueRotate2Filter");
var hueRotate3FilterButton = document.getElementById("hueRotate3Filter");
var invertFilterButton = document.getElementById("invertFilter");
var sepiaFilterButton = document.getElementById("sepiaFilter");
var noneFilterButton = document.getElementById("noneFilter");

var forActivate = [
	saveButttonItem,
	cancelAllButttonItem,
	document.getElementById("resizeAction"),
	document.getElementById("rightRotate"),
	document.getElementById("leftRotate"),
]

var filters = [
	blurFilterButton,
	brightnessFilterButton,
	notBrightnessFilterButton,
	contrastFilterButton,
	shadowFilterButton,
	grayscaleFilterButton,

	hueRotate1FilterButton,
	hueRotate2FilterButton,
	hueRotate3FilterButton,
	invertFilterButton,
	sepiaFilterButton,
	noneFilterButton,
]
var widthSize = 0, heightSize = 0;
var resizeDivState = 0;
var angle = 0;
var size = 0, startSize = 0;
var filter = 'none';

function calcAngle(incAngle) {
	angle = angle + incAngle;
	if (angle < 0) {
		angle = angle + 360;
	}
	if (angle >= 360) {
		angle = angle - 360;
	}
}

function setCanvasTitle(width, height) {
	canvas.title = "ширина: " + width + "; высота: " + height + "; изначальный размер:" + size + " байт;"; // loc
}

function settingCanvasByAngle() {
	var context = canvas.getContext("2d");
	var imgUrl = imageUrlInput.value;
	var img = new Image();

	img.onload = function () {
		context.save();
		context.clearRect(0, 0, canvas.width, canvas.height);
		var w, h;

		switch (angle) {
			case 90:
				canvas.width = heightSize;
				canvas.height = widthSize;
				setCanvasTitle(heightSize, widthSize);
				context.translate(heightSize, 0);
				break;
			case 180:
				canvas.width = widthSize;
				canvas.height = heightSize;
				setCanvasTitle(widthSize, heightSize);
				context.translate(widthSize, heightSize);
				break;
			case 270:
				canvas.width = heightSize;
				canvas.height = widthSize;
				setCanvasTitle(heightSize, widthSize);
				context.translate(0, widthSize);
				break;
			default:
				canvas.width = widthSize;
				canvas.height = heightSize;
				setCanvasTitle(widthSize, heightSize);
		}

		context.rotate(angle * Math.PI / 180);
		context.filter = filter;
		context.drawImage(img, 0, 0, widthSize, heightSize);
		context.restore();

		if (resizeDivState == 1) {
			showResizeDiv();
			changeSizeW_change();
			changeSizeH_change();
		}
	};
	img.src = imgUrl;
}

function rotateLeft_click() {
	calcAngle(-90);
	settingCanvasByAngle();
}

function rotateRight_click() {
	calcAngle(90);
	settingCanvasByAngle();
}

function inputFile_changed(files) {
	if (!files.length) {
		return;
	}

	var context = canvas.getContext("2d");
	var imgUrl = window.URL.createObjectURL(files[0])
	var img = new Image();

	img.onload = function () {
		heightSize = this.height;
		widthSize = this.width;
		canvas.width = this.width;
		canvas.height = this.height;

		size = files[0].size;
		startSize = size;
		setCanvasTitle(this.width, this.height);

		context.drawImage(img, 0, 0);
	};

	imageUrlInput.value = imgUrl;
	img.src = imgUrl;

	hideResizeDiv();
	activateElements();
	deleteTitles();
	angle = 0;
	filter = "none";
	someFiterClick(noneFilterButton);
}

function canselAll_click() {
	if (!imageUrlInput.value.length) {
		alert("Что-то пошло не так."); // loc
		return;
	}

	var context = canvas.getContext("2d");
	var img = new Image();

	img.onload = function () {
		heightSize = this.height;
		widthSize = this.width;
		canvas.width = this.width;
		canvas.height = this.height;

		size = startSize;
		setCanvasTitle(this.width, this.height);

		context.drawImage(img, 0, 0);
	};

	img.src = imageUrlInput.value;

	hideResizeDiv();
	activateElements();
	deleteTitles();
	angle = 0;
	filter = "none";
	someFiterClick(noneFilterButton);
}


function hideResizeDiv() {
	if (changeSizeDiv.classList.contains('change-size-div-show')) {
		changeSizeDiv.classList.remove('change-size-div-show');
	}
	resizeDivState = 0;
}

function showResizeDiv() {
	changeSizeH.max = canvas.height;
	changeSizeW.max = canvas.width;
	changeSizeH.value = canvas.height;
	changeSizeW.value = canvas.width;

	document.getElementById('changeSizeHDiv').title = 'максимальное значение: ' + canvas.height; // loc
	document.getElementById('changeSizeWDiv').title = 'максимальное значение: ' + canvas.width; // loc

	if (!changeSizeDiv.classList.contains('change-size-div-show')) {
		changeSizeDiv.classList.add('change-size-div-show');
	}
	resizeDivState = 1;
}

function changeSizeBtn_click() {
	heightSize = changeSizeH.value;
	widthSize = changeSizeW.value;

	hideResizeDiv();

	settingCanvasByAngle();
}

function resizeAction_click() {
	if (resizeDivState == 0) {
		showResizeDiv();
	}
	else {
		hideResizeDiv();
	}
}

function save_click() {
	var url = canvas.toDataURL('image/jpeg');
	console.log(url);

	console.log('before start');
	addImage(url);
	console.log('after finish'); 
}

function saveImage(url) {
	if (typeof (downloadLnkItem) != 'undefined' && downloadLnkItem != null) {
		downloadLnkItem.href = url;
		downloadLnkItem.click();
		console.log('img downloaded'); 
	}
}

function changeSizeH_change() {
	if (changeSizeH.value > canvas.height) {
		changeSizeH.value = canvas.height;
    }
}

function changeSizeW_change() {
	if (changeSizeW.value > canvas.width) {
		changeSizeW.value = canvas.width;
	}
}

function open_click() {
	fileInputItem.click();
}

function deleteTitles() {
	for (var i = 0; i < filters.length; i++) {
		filters[i].title = "";
	}
	for (var i = 0; i < forActivate.length; i++) {
		forActivate[i].title = "";
	}

	cancelAllButttonItem.title = "Откатить все сделанные изменения."; // loc
}

function activateElements() {
	for (var i = 0; i < filters.length; i++) {
		filters[i].disabled = false;
	}
	for (var i = 0; i < forActivate.length; i++) {
		forActivate[i].disabled = false;
	}
}

function someFiterClick(button) {
	for (var i = 0; i < filters.length; i++) {
		filters[i].style.fontWeight = "400";
		filters[i].style.backgroundColor = "#d4fff8";
	}

	button.style.fontWeight = "600";
	button.style.backgroundColor = "#a1ffca";
}


function noneFiltrButton_click() {
	filter = 'none';
	settingCanvasByAngle();
	someFiterClick(noneFilterButton);
}

function blurFiltrButton_click() {
	filter = 'blur(3px)';
	settingCanvasByAngle();
	someFiterClick(blurFilterButton);
}

function brightnessFiltrButton_click() {
	filter = "brightness(150%)";
	settingCanvasByAngle();
	someFiterClick(brightnessFilterButton);
}

function notBrightnessFiltrButton_click() {
	filter = "brightness(50%)";
	settingCanvasByAngle();
	someFiterClick(notBrightnessFilterButton);
}

function contrastFiltrButton_click() {
	filter = "contrast(25%)";
	settingCanvasByAngle();
	someFiterClick(contrastFilterButton);
}

function shadowFiltrButton_click() {
	filter = "drop-shadow(0 0 3px rgba(100,0,0,0.5))";
	settingCanvasByAngle();
	someFiterClick(shadowFilterButton);
}

function grayscaleButton_click() {
	filter = 'grayscale(1)';
	settingCanvasByAngle();
	someFiterClick(grayscaleFilterButton);
}

function invertButton_click() {
	filter = "invert(100%)";
	settingCanvasByAngle();
	someFiterClick(invertFilterButton);
}

function hueRotate1Button_click() {
	filter = "hue-rotate(90deg)";
	settingCanvasByAngle();
	someFiterClick(hueRotate1FilterButton);
}

function hueRotate2Button_click() {
	filter = "hue-rotate(180deg)";
	settingCanvasByAngle();
	someFiterClick(hueRotate2FilterButton);
}

function hueRotate3Button_click() {
	filter = "hue-rotate(270deg)";
	settingCanvasByAngle();
	someFiterClick(hueRotate3FilterButton);
}

function sepiaFiltrButton_click() {
	filter = "sepia(75%)";
	settingCanvasByAngle();
	someFiterClick(sepiaFilterButton);
}

function backOrClose() {
	var prevPage = window.location.href;
	window.history.back();

	setTimeout(function () {
		if (window.location.href == prevPage) {
			window.close();
		}
	}, 500);
}

function notification_click(elementId) {
	var link = document.getElementById(elementId);
	link.click();

	var td = document.getElementsByName(elementId);

	if (td.classList.contains('td-notice-read')) {
		td.classList.remove('td-notice-read');
		td.classList.add('td-notice-new');
	}
	else {
		td.classList.remove('td-notice-new');
		td.classList.add('td-notice-read');
    }
}

document.querySelector("input[name='email']").addEventListener("keypress", (event) => {
	var validCharCodes = [
		//"!", "#", "$", "%", "&", "'", "*", "+", "-", "/", "\\", "=", "?", "^", "_", "`", "{", "|", "}", "~", "@", ".", "0-9", "a-z", "A-Z"
		33, 35, 36, 37, 38, 39, 42, 43, 45, 46, 47, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 63, 64, 65, 66, 67, 68, 69, 70, 71, 72, 73, 74, 75, 76, 77, 78, 79, 80,
		81, 82, 83, 84, 85, 86, 87, 88, 88, 89, 90, 94, 95, 96, 97, 98, 99, 100, 101, 102, 103, 104, 105, 106, 107, 108, 109, 110, 111, 112, 113, 114, 115, 116,
		117, 118, 119, 120, 121, 122, 123, 124, 125, 126
	];

	if (!validCharCodes.includes(event.charCode)) {
		event.preventDefault();
	}
	console.log("inputed in email field(char code) = " + event.charCode);
});