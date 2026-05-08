// Script para transiciones de página con overlay gamer profesional

document.addEventListener('DOMContentLoaded', function() {
    const overlay = document.getElementById('pageTransitionOverlay');
    
    if (!overlay) {
        console.warn('Page transition overlay not found');
        return;
    }

    // Función para iniciar transición
    function triggerTransition(href) {
        overlay.classList.add('active', 'slide-in');
        
        // Esperar a que termine la animación
        setTimeout(() => {
            window.location.href = href;
        }, 600);
    }

    // Detectar todos los links de navegación internos
    const navLinks = document.querySelectorAll('a[href]');
    
    navLinks.forEach(link => {
        const href = link.getAttribute('href');
        
        // Verificar que sea un link interno válido
        if (href && 
            !href.startsWith('http') && 
            !href.startsWith('#') && 
            !href.startsWith('javascript:') &&
            !link.hasAttribute('target') &&
            href !== '' &&
            href !== '/') {
            
            link.addEventListener('click', function(e) {
                e.preventDefault();
                triggerTransition(href);
            });
        }
    });

    // También para los botones de envío de formularios que naveguen
    const forms = document.querySelectorAll('form');
    forms.forEach(form => {
        form.addEventListener('submit', function(e) {
            // Permitir que se envíe el formulario normalmente
            // Las transiciones ocurrirán en la redirección
        });
    });

    // Limpiar la animación cuando la página carga completamente
    window.addEventListener('load', function() {
        overlay.classList.remove('active', 'slide-in');
    });

    // También manejar el botón atrás del navegador
    window.addEventListener('beforeunload', function() {
        overlay.classList.add('active', 'slide-in');
    });
});

console.log('Page transitions script loaded');

