export default function CreateTaskList(DataSet = [], TaskList) {
    TaskList.innerText = "";

    DataSet.forEach((item, index) => {
        const task = document.createElement('div');
        for (var prop in item) {
            task.innerText = item[prop];
        }

        task.classList.add('container', 'taskelement');
        task.addEventListener('click', changeTaskState);
        TaskList.prepend(task);
    });
}