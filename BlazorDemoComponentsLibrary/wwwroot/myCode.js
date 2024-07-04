//import { mioSaluto } from './myDependencies'; 

export function miaSomma(a, b) {    
    return a + b;
}

export function sommaQuadratica (a, b, c) {
   // var saluto = mioSaluto("Salvatore");
   // console.log(saluto);
    var somma = a * a + b * b + c * c;
    console.log(somma);
    return somma;
}

export function restituisceArrayAsync() {
    DotNet.invokeMethodAsync('BlazorDemoComponentsLibrary', 'RestituisceArrayAsync')
     .then(data => {
            console.log(data);
        });
}

export function sayHello(helloHelper) {
    helloHelper.invokeMethodAsync('SayHello')
        .then( data => console.log(data));
}





