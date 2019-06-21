console.log("Entro");

var canvas = document.getElementById('CanvasDibujo');
var ctx = canvas.getContext('2d');
var mouse = { x: 0, y: 0 };

var CanPostura = document.getElementById('CanvasPostura');
var ctxPostura = CanPostura.getContext('2d');
var Imagen = new Image();
Imagen.src = 'postura.png';

Imagen.onload = function () {
    ctxPostura.drawImage(Imagen, 0, 0);
};

canvas.addEventListener('mousemove', function (e) {
    mouse.x = e.pageX - this.offsetLeft;
    mouse.y = e.pageY - this.offsetTop;
}, false);

ctx.lineWidth = 3;
ctx.lineJoin = 'round';
ctx.lineCap = 'round';
ctx.strokeStyle = 'blue';

function Borrador() {
    ctx.globalCompositeOperation = 'destination-out';
    ctx.lineWidth = 5;

    canvas.addEventListener('mousedown', function (e) {
        ctx.beginPath();
        ctx.moveTo(mouse.x, mouse.y);

        canvas.addEventListener('mousemove', onPaint, false);
    }, false);

    canvas.addEventListener('mouseup', function () {
        canvas.removeEventListener('mousemove', onPaint, false);
    }, false);

    var onPaint = function () {
        ctx.lineTo(mouse.x, mouse.y);
        ctx.stroke();
    };

    return false;
}

function Lapiz() {
    console.log("Entro Lapiz");
    ctx.globalCompositeOperation = 'source-over';

    canvas.addEventListener('mousedown', function (e) {
        ctx.beginPath();
        ctx.moveTo(mouse.x, mouse.y);

        canvas.addEventListener('mousemove', onPaint, false);
    }, false);

    canvas.addEventListener('mouseup', function () {
        canvas.removeEventListener('mousemove', onPaint, false);
    }, false);

    var onPaint = function () {
        ctx.lineTo(mouse.x, mouse.y);
        ctx.stroke();
    };

    return false;
}

function Grosor(obj) {
    ctx.lineWidth = obj.value
    return false;
}

function BorrarTodo() {
    ctx.clearRect(0, 0, 350, 613);
    return false;
}

function Unir() {
    var can3 = document.getElementById('CanvasFinal');
    var ctx3 = can3.getContext('2d');
    ctx3.drawImage(CanPostura, 0, 0);
    ctx3.drawImage(canvas, 0, 0);

    return false;
}

function Guardar() {
    var can3 = document.getElementById('CanvasFinal');
    var ctx3 = can3.getContext('2d');
    ctx3.drawImage(CanPostura, 0, 0);
    ctx3.drawImage(canvas, 0, 0);

    return false;
}