#!/bin/bash
​
#----------- Auxiliar functions -----------
function clean_obj()
{
    echo "> Limpiando obj..."
    find . -regex '^.*/obj$' | xargs rm -r
    echo "> Fin limpieza obj!"
}
​
function clean_bin()
{
    echo "> Limpiando bin..."
    find . -regex '^.*/bin$' | xargs rm -r
    echo "> Fin limpieza bin!"
}
​
#----------- Main -----------
clean_obj
clean_bin