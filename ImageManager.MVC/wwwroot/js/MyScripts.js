var canvas = document.getElementById("myCanvas");
var imageUrlInput = document.getElementById("imageUrl");
var fileInputItem = document.getElementById("fileInputItem");

function inputFile_changed(files) {
	if (!files.length) {
		return;
	}

	var context = canvas.getContext("2d");
	var imgUrl = window.URL.createObjectURL(files[0])
	var img = new Image();

	img.onload = function () {
		canvas.width = this.width;
		canvas.height = this.height;
		canvas.title = "ширина: " + this.width + "; высота: " + this.height + "; " + files[0].size + " байт;";

		context.drawImage(img, 0, 0, this.width, this.height);
	};

	imageUrlInput.value = imgUrl;
	img.src = imgUrl;
}

function open_click() {
	fileInputItem.click();
}
