const toggleTasksBtn = document.querySelector('.toggle-tasks')
const createTaskBtn = document.querySelector('.toggle-create')
const formCreate = document.getElementById('create-container')
const closerCreateBtn = document.querySelector('.close-create')

createTaskBtn.addEventListener('click', () => {
    formCreate.classList.add('translate-0')
})

closerCreateBtn.addEventListener('click', () => {
    formCreate.classList.remove('translate-0')
})

toggleTasksBtn.addEventListener('click', () => {
    const tareasTable = document.getElementById('tareas-table')

    tareasTable.classList.toggle('d-none')
    getTasks()
})

function getTasks() {
    const url = "Tarea/GetTareas"
    fetch(url)
        .then(response => response.json())
        .then(data => {
            console.log(data)
            const tableBody = document.querySelector('#renderLst')
            data.forEach(tarea => {
                const row = document.createElement('tr');
                row.innerHTML = `
                    <td>${tarea.title}</td>
                    <td>${new Date(tarea.fechaCreacion).toLocaleDateString()}</td>
                    <td>${new Date(tarea.fechaEstimadaEntrega).toDateString()}</td>
                    <td>${tarea.estado}</td>
                    <td>${tarea.prioridad}</td>
                    <td>${tarea.categoria}</td>
                        <td>${tarea.asiggnadoA}</td>
                    <td>
                        <a class="btn btn-warning" href="/Tarea/Edit/${tarea.idTarea}">
                            <i class="fa-solid fa-pen-to-square"></i>
                        </a> |
                        <a class="btn btn-secondary" href="/Tarea/Details/${tarea.idTarea}">
                            <i class="fa-solid fa-circle-info"></i>
                        </a> |
                        <a class="btn btn-danger" href="/Tarea/Delete/${tarea.idTarea}">
                            <i class="fa-solid fa-circle-info"></i>
                        </a>
                    </td>
                `;
                tableBody.appendChild(row);
            });
        })
        .catch(error => console.error('Error:', error));
}