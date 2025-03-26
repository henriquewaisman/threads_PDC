import { Worker } from 'worker_threads';

function prepararItem(item, tempo) {
    return new Promise((resolve) => {
        const worker = new Worker('./worker.js', { workerData: { item, tempo } });
        worker.on('message', resolve);
    });
}

async function lanchePronto() {
    console.log("Pedido recebido! Preparando...");

    const [pipoca, refrigerante] = await Promise.all([
        prepararItem("Pipoca", 2000),
        prepararItem("Refrigerante", 1500)
    ]);

    console.log(pipoca);
    console.log(refrigerante);
    console.log("Lanche pronto! Você pode retirar seu pedido.🍿🥤");
}

lanchePronto();
