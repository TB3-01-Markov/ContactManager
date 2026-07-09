// vfktymrbt b ,jkmibt ,erds d gjbcrt 'nj ljk;yj ,snm jlyj b nj;t
// Добавить обработку нажатия клавши ЕНТЕР в формах подверждающих на сохранение/удаление
// Сделать вариант с храненем контактов в кики браузера в сторадже и сделать переподключение куки/текстовій_файл и возможно интерфес как айконтакт репозитори
// реализовать хранение в формате джейсон
// ассинхронніе функции джаваскрипт
// реализовать валидацию и проверку полей
// обработать все исключения  // написать собвсвенніе исключения
// добавить возможность иметь два емейла, телефона а также добавить поле социальніе медиа
// поиск. реализовать что бы искала с начала каждого слова а не просто (ton=>Dayton)
// исправить ид, сейчас пока у всех 1
// реализовать работу со списком а не с дуум-елементами для всех функций.
// добавить по возможности шифровку/дешефровку при загрузке сохранения
// сохранять, закгружать, обновлять не все контакты разом а конкретный контакт, конкретное поле,
// економить вычислительную мозность, интернет, память.
// соеденить с сишарпом
// захостить сайт онлайн
// удалить нерабочие елементі или сделать их рабочими
// проверить работу с списком контактов а не просто списком полей до конца
// исправть имена на более понятные и однозначные
// универсилизировать и разделить функции
// разнести джаваскрипт и возможно хтпм и цсс на разніе файлі
// логика должна біть кристально ясной
// реализовать поиск в строке сайта
// разобрать с локалхостом и с пакедж.джейсон
// сохранить в отдельную ветку гитхаба
// реализовать загузкук контактов с ватсап, вайбер, фейсбук, тлеграм, гуглконтакты, телефон, выгруженные файлы.
// создать более сложную структуру контактов, включающие несколько мейлов=телефонов,контакрті месеннджеров, соцальніх сетей, сайтов, звестніе логині|пароли описание персонажа контактов, время добавления=изменения контакта,
// реализовать возможность звонить на контакт с перекидованием на телефон, иптелефонию, месенджер и так далее
// добавить поле имяконтактноголиста/группі , добавить возможость группировать контакті
// добавить инфографику, иконки трубк, мессенджера, соцcети.
// либо перекидовать на емейл для написания письма либо реализовать в самом приложениее возможность писать и отправлять писма
// функця проверить на ошибки текст письма при помощи нейросети
// добавить возможность хранить фотографии контактов=персонажей
// добавить возможность диктофона разговора
// собирать активность контактов
// проверить и заоплосить все желтые предупреждения
//добавить тесты фронтенда на джаваскрипт
//сделать так что бі вверх с контакттогевонен не отставался вверху а по мере пролистіваня вниз опускался тоже как шапка
//отдельній жс и возможно клас для управления дом елементами
//подумать о том что бі написать класс в стораджелист и добавить в него функции
// изменить тему студии в норму

    /*
document.querySelector('#tbodycontacten').addEventListener('click', function (e) {
if (e.target.classList.contains('update-btn')) 
и/или
const saveBtn = document.getElementById("addsave-btn");
saveBtn.addEventListener("click", () => {
    */

/*let contacts = [
    { id: 1, name: "Mark Meyers", phone: "+32 473 31 32 66", email: "markmeyers@gmail.com" },
    { id: 2, name: "Lucas Gent", phone: "+32 473 13 24 41", email: "lucasgent9000@gmail.com" },
    { id: 3, name: "Phillip Olimpiado", phone: "+32 473 21 24 39", email: "philipvanbrugge1@gmail.com" },
];*/

/*
saveBtn.addEventListener("click", () => {
    const name = document.getElementById("addName").value;
    const phone = document.getElementById("addPhone").value;
    const email = document.getElementById("addEmail").value;

    const rows = tbody.querySelectorAll("tr");
    const rowlenght = tbody.rows.length;
    // lastId = rows.length > 0 ? parseInt(rows[rows.length - 1].querySelector(".td-id").textContent): 0;
    let lastId = 0;
    if (rows.length > 0) {
        const lastCell = rows[rows.length - 1].querySelector("td:first-child");
        lastId = parseInt(lastCell.textContent) || 0;
    }

    const row = document.createElement("tr");
    row.id = "tr-contact";

    row.innerHTML = `
        <td class="td-id">${lastId + 1}</td>
        <td class="td-name">${name}</td>
        <td class="td-phone">${phone}</td>
        <td class="td-mail">${email}</td>
        <td>
            <button class="blue-button update-btn">UPDATE</button>
            <button class="red-button  delete-btn">DELETE</button>
        </td>`;
    tbody.appendChild(row);
    contactSection.classList.add("hidden");
});
*/

/*
document.querySelectorAll('.delete-btn').forEach(button => {
    button.addEventListener('click', function () {
        const row = this.closest('tr');
        row.remove();
    });
});
*/

/*
document.querySelector('#tbodycontacten').addEventListener('click', function (e) {
    if (e.target.classList.contains('update-btn')) {
        document.getElementById("h3contacten").textContent = 'Update Contact';
    }
});
*/

/*
function stringToContact(s) {
    const parts = s.split("<&>");
    return {
        id: parseInt(parts[0]),
        name: parts[1],
        email: parts[2],
        phone: parts[3]
    };
}
*/