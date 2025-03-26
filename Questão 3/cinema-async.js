function getPipoca() {
    return new Promise((resolve) => {
        setTimeout(() => {
            resolve("Pipoca Pronta");
        }, 4000);
    });
}

function getRefrigerante() {
    return new Promise((resolve) => {
        setTimeout(() => {
            resolve("Refrigerante Pronto");
        }, 3000);
    });
}

async function prepararLanche() {
    console.log("Pedido recebido! Preparando...");

    const pipoca = await getPipoca();
    const refrigerante = await getRefrigerante();

    console.log(pipoca);
    console.log(refrigerante);
    console.log("Lanche pronto! Você pode retirar seu pedido.🍿🥤");
}

prepararLanche();
