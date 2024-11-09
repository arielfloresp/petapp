document.addEventListener('DOMContentLoaded', () => {
    document.body.style.backgroundColor = '#2C3E50'; // Fondo sólido elegante y minimalista
    document.body.style.color = '#ECF0F1';           // Color de texto claro para buen contraste

    const menuIcon = document.getElementById('menu-icon');
    const dropdownMenu = document.getElementById('dropdown-menu');

    menuIcon.addEventListener('click', (event) => {
        event.stopPropagation();
        if (dropdownMenu.classList.contains('show')) {
            dropdownMenu.classList.remove('show');
            setTimeout(() => {
                dropdownMenu.style.display = 'none';
            }, 300);
        } else {
            dropdownMenu.style.display = 'block';
            setTimeout(() => {
                dropdownMenu.classList.add('show');
            }, 0);
        }
    });

    dropdownMenu.addEventListener('click', (event) => {
        event.stopPropagation();
    });

    document.addEventListener('click', () => {
        if (dropdownMenu.classList.contains('show')) {
            dropdownMenu.classList.remove('show');
            setTimeout(() => {
                dropdownMenu.style.display = 'none';
            }, 300);
        }
    });

    // Redirección al formulario de registro de mascotas
    const loginForm = document.querySelector('.login-form');
    loginForm.addEventListener('submit', function (event) {
        event.preventDefault();
        window.location.href = 'perros.html';
    });
});
