const dateNumber = document.getElementById('date-number');
const dateMonth = document.getElementById('datemonth');
const dateYear = document.getElementById('dateyear');
const dateDay = document.getElementById('dateday');
const taskList = document.getElementById('tasklist');

const setDate = () => {
    const date = new Date();
    dateNumber.textContent = date.toLocaleDateString('es', { day: 'numeric' });
    dateMonth.textContent = date.toLocaleDateString('es', { month: 'short' });
    dateYear.textContent = date.toLocaleDateString('es', { year: 'numeric' });
    dateDay.textContent = date.toLocaleDateString('es', { weekday: 'long' });
}

const addNewTask = event => {
    event.preventDefault();
    const { value } = event.target.taskTitle;
    if (!value) return;
    const task = document.createElement('div');
    task.classList.add('container', 'taskelement');
    task.addEventListener('click', changeTaskState);
    task.textContent = value;
    taskList.prepend(task);
    event.target.reset();
}

const changeTaskState = event =>{
    event.target.classList.toggle('done')
}

const order = () => {
    const done = [];
    const toDo = [];
    taskList.childNodes.forEach(el => {
        el.classList.contains('done')? done.push(el) : toDo.push(el);
    })
    return [...toDo, ...done];
}

const renderOrderedTasks = () => {
    order().forEach(el => taskList.appendChild(el))
}

setDate();