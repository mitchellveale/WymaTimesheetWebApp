


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
