window.miaSomma = function (a, b) {
    return a + b;
}

window.sommaQuadratica = function (a, b, c) {
    var saluto = mioSaluta("Salvatore");
    console.log(saluto);
    var somma = a * a + b * b + c * c;
    console.log(somma);
    return somma;
}

function mioSaluta(nome) {
    return "Ciao " + nome + "!";
}
