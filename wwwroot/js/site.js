// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


/*FUNKCIJA ZA TRENUTNO VRIJEME U ZAGLAVLJU*/

function Vrijeme() {
    time = new Date()
    sat = time.getHours()
    minuti = time.getMinutes()
    sekunde = time.getSeconds()
    temp = "" + ((sat > 12) ? sat - 12 : sat)
    temp += ((minuti < 10) ? ":0" : ":") + minuti
    temp += ((sekunde < 10) ? ":0" : ":") + sekunde
    temp += ((sat >= 12) ? " P.M." : " A.M.")
    document.vrijemeForma.cifre.value = temp
    setTimeout("Vrijeme()", 1000)
    //posle svakih 1000milisekundi, odnosno 1 sekunde
    //ponovo se ucitava funkcija Vrijeme()
}






