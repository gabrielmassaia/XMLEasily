function applyFilters() {
    const date = document.getElementById('dateFilter').value;
    const integrator = document.getElementById('integratorFilter').value;
    const url = `/?dateFilter=${date}&integratorFilter=${integrator}`;
    window.location.href = url;
}

function clearFilters() {
    window.location.href = '/';
}

function openFile(filePath) {
    fetch(`/Home/Open?filePath=${encodeURIComponent(filePath)}`)
        .then(response => response.text())
        .then(data => {
            document.getElementById('content-display').innerText = data;
            document.querySelector('.file-content').classList.remove('hidden');
        });
}

function closeContent() {
    document.querySelector('.file-content').classList.add('hidden');
}

function downloadFile(filePath) {
    window.location.href = `/Home/Download?filePath=${encodeURIComponent(filePath)}`;
}


document.addEventListener("DOMContentLoaded", () => {
    const btnVoltar = document.getElementById("btn-voltar");

    // Simula abrir uma cotação
    document.querySelectorAll(".btn-open").forEach(button => {
        button.addEventListener("click", () => {
            // Mostra o botão de voltar
            btnVoltar.style.display = "block";
        });
    });

    // Lógica para o botão de voltar
    btnVoltar.addEventListener("click", () => {
        // Esconde o botão de voltar
        btnVoltar.style.display = "none";

        // Lógica adicional para restaurar a visualização anterior
        alert("Voltando à lista de cotações...");
    });
});
