function initMap() {
    // The location of Aracaju
    const aracaju = { lat: -11.0056387, lng: -37.2432446 };
    const belohorizonte = { lat: -19.9027163, lng: -43.9640501 };
    const curitiba = { lat: -25.4947401, lng: -49.4298853 };
    // The map, centered at Aracaju
    const map = new google.maps.Map(document.getElementById("map"), {
        zoom: 4,
        center: aracaju,
    });
    // The marker, positioned at Aracaju
    new google.maps.Marker({
        position: aracaju,
        map,
        title: "Serviço de Apoio Psicológico Remoto - Aracaju/Sergipe - (79) 3304-3599 ou 0800 729-3534, de segunda a sexta-feira, das 8h às 20h - gratuito",
    });
    new google.maps.Marker({
        position: belohorizonte,
        map,
        title: "Cuidados Psicológicos no Contexto da Pandemia - Belo Horizonte/Minas Gerais - Os Agendamentos das consultas devem ser feitos nos centros de saúde de BH - gratuito",
    });
    new google.maps.Marker({
        position: curitiba,
        map,
        title: "Associação Paranaense de Terapia Familiar - Curitiba/Paraná - https://docs.google.com/forms/d/e/1FAIpQLSel6NWj90ryp7gS9DRIqf1sUVsjifHZtzvJD3t2d8BGctkE6A/viewform - gratuito",
    });
}