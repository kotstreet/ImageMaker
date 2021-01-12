// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
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