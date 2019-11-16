function go(link) {
    window.open(link);
}

function keyDown(e) {
    DotNet.invokeMethodAsync('ToshaSite', 'KeyDown', e.key);
}

function keyUp(e) {
    DotNet.invokeMethodAsync('ToshaSite', 'KeyUp', e.key);
}