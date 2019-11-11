function go(link) {
    window.open(link);
}

function show() {
    DotNet.invokeMethodAsync('ToshaSite', 'GetNum')
        .then(data => alert(data));
}