


var canvas = document.querySelector("canvas");



var signaturePad = new SignaturePad(canvas, {
    minWidth: 1,
    maxWidth: 1,
    dotSize: 0.1,

    penColor: "rgb(0, 0, 0)"
});

signaturePad.on();


function saveSig() {

    var save = signaturePad.toDataURL("image/svg+xml");
    document.getElementById("hiddenfield").value = save;
}


function resizeCanvas() {
    var ratio = Math.max(window.devicePixelRatio || 1, 1);
    canvas.width = canvas.offsetWidth * ratio;
    canvas.height = canvas.offsetHeight * ratio;
    canvas.getContext("2d").scale(ratio, ratio);
    signaturePad.clear(); // otherwise isEmpty() might return incorrect value
}

window.addEventListener("resize", resizeCanvas);
resizeCanvas();


