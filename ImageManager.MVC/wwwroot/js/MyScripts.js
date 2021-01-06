var canvas = document.getElementById("myCanvas");
var imageUrlInput = document.getElementById("imageUrl");
var fileInputItem = document.getElementById("fileInputItem");
var downloadLnkItem = document.getElementById("downloadLnk");

var saveButttonItem = document.getElementById("saveButtton");
var cancelAllButttonItem = document.getElementById("canselAllButtton");
var imageActionDivItem = document.getElementById("imageActionDiv");

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
	document.getElementById("cutAction"),
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

function calcCanvasWidth(width) {
	canvas.width = width;
}

function calcCanvasHeight(height) {
	canvas.height = height;
}

function setCanvasTitle(width, height) {
	canvas.title = "ширина: " + width + "; высота: " + height + "; " + size + " байт;";
}

function settingCanvasByAngle() {
	var context = canvas.getContext("2d");
	var imgUrl = imageUrlInput.value;
	var img = new Image();

	img.onload = function () {
		context.save();
		context.clearRect(0, 0, canvas.width, canvas.height);

		switch (angle) {
			case 90:
				calcCanvasWidth(this.height);
				calcCanvasHeight(this.width);
				setCanvasTitle(this.height, this.width);
				context.translate(this.height, 0);
				break;
			case 180:
				calcCanvasWidth(this.width);
				calcCanvasHeight(this.height);
				setCanvasTitle(this.width, this.height);
				context.translate(this.width, this.height);
				break;
			case 270:
				calcCanvasWidth(this.height);
				calcCanvasHeight(this.width);
				setCanvasTitle(this.height, this.width);
				context.translate(0, this.width);
				break;
			default:
				calcCanvasWidth(this.width);
				calcCanvasHeight(this.height);
				setCanvasTitle(this.width, this.height);
		}

		context.rotate(angle * Math.PI / 180);
		context.filter = filter;
		context.drawImage(img, 0, 0);
		context.restore();
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
		calcCanvasWidth(this.width);
		calcCanvasHeight(this.height);

		size = files[0].size;
		startSize = size;
		setCanvasTitle(this.width, this.height);

		context.drawImage(img, 0, 0);
	};

	imageUrlInput.value = imgUrl;
	img.src = imgUrl;

	activateElements();
	deleteTitles();
	angle = 0;
	filter = "none";
	someFiterClick(noneFilterButton);
}

function canselAll_click() {
	if (!imageUrlInput.value.length) {
		alert("Что-то пошло не так.");
		return;
	}

	var context = canvas.getContext("2d");
	var img = new Image();

	img.onload = function () {
		calcCanvasWidth(this.width);
		calcCanvasHeight(this.height);

		size = startSize;
		setCanvasTitle(this.width, this.height);

		context.drawImage(img, 0, 0);
	};

	img.src = imageUrlInput.value;

	activateElements();
	deleteTitles();
	angle = 0;
	filter = "none";
	someFiterClick(noneFilterButton);
}

function settingNewCanvas(newCanvas, width, height) {
	var max = 200;

	if (height > max) {
		var index = height / max;
		newCanvas.height = max;
		newCanvas.width = width / index;
	}
	else {
		newCanvas.width = width;
		newCanvas.height = height;
    }

}

function save_click() {
	var url = canvas.toDataURL('image/jpeg');
	console.log(url); 

	downloadLnkItem.href = url;
	downloadLnkItem.click();

	var resizedCanvas = document.createElement("canvas");
	var resizedContext = resizedCanvas.getContext("2d");

	settingNewCanvas(resizedCanvas, canvas.width, canvas.height);

	resizedContext.drawImage(canvas, 0, 0, resizedCanvas.width, resizedCanvas.height);
	var myResizedData = resizedCanvas.toDataURL('image/jpeg');
	console.log("myResizedData = " + myResizedData);

	console.log('before start'); 
	addImage(myResizedData);
	console.log('after finish'); 
}


function open_click() {
	fileInputItem.click();
}

function deleteTitles() {
	imageActionDivItem.title = "";
	cancelAllButttonItem.title = "Откатить все сделанные изменения.";
	saveButttonItem.title = "";
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