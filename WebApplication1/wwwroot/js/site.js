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
