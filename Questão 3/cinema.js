function getPipoca() {
    console.log('Preparando a pipoca')
    return new Promise((resolve) => {
        setTimeout(() => {
            resolve("Pipoca Pronta");
        }, 4000);
    });
}

function getRefrigerante() {
    console.log('Preparando o refrigerante')
    return new Promise((resolve) => {
        setTimeout(() => {
            resolve("Refrigerante Pronto");
        }, 3000);
    });
}

async function lanchePronto() {
    console.log("Pedido recebido! Preparando...");
    
    const [pipoca, refrigerante] = await Promise.all([getPipoca(), getRefrigerante()]);
    
    console.log(pipoca);
    console.log(refrigerante);
    console.log("Lanche pronto! Você pode retirar seu pedido.🍿🥤");
}

lanchePronto();
