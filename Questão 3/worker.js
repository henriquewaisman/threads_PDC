import { parentPort, workerData } from 'worker_threads';

setTimeout(() => {
    parentPort.postMessage(`${workerData.item} pronto`);
}, workerData.tempo);
