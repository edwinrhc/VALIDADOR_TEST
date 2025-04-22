# Proyecto de Validador TEST en Visual Basic .NET

## Descripción

Este proyecto está diseñado para procesar archivos, realizar consultas y generar archivos PDF y de log, mostrando los resultados finales al usuario. Implementa una arquitectura por capas que incluye módulos para validación, procesamiento y manejo de información.

# 🧾 Sistema de Carga Masiva (Migración Oracle Forms → VB.NET)

Este proyecto fue desarrollado para migrar un sistema antiguo construido con Oracle Forms 6 a una solución moderna de escritorio con Visual Basic. El objetivo fue optimizar el proceso de carga de archivos masivos con más de 20,000 registros, reduciendo el tiempo de espera de 25 minutos aproximadamente a solo 2 minutos.


## Características principales
- Lectura de archivos TXT (encabezado, cuerpo y errores)
- Carga a base de datos Oracle
- Generación de código de proceso
- Reporte detallado y log de errores
- Optimización de tiempos y uso de memoria

## Características principales

- Carga y procesamiento de archivos.
- Generación de archivos PDF con **iTextSharp**.
- Creación de archivos de log para rastrear el procesamiento.
- Consultas y procesamiento de la información cargada.
- Uso de **OpenXML** para el manejo de documentos de Excel.

## Estructura de Capas

El proyecto sigue una arquitectura por capas para garantizar una separación clara de responsabilidades:

- **Capa Constantes:** Define constantes globales utilizadas en el proyecto.
- **Capa D_Validador:** Capa de acceso a datos, encargada de interactuar con la base de datos y realizar las consultas necesarias.
- **Capa E_Validador:** Define las entidades de datos (modelos) que se utilizan para representar la información que se procesa.
- **Capa N_Validador:** Lógica de negocio. Aquí se procesan las reglas y la lógica central del sistema.
- **Capa Validador:** Capa de presentación o aplicación principal donde se interactúa con el usuario y se gestionan las acciones del sistema.

## Dependencias

Este proyecto utiliza las siguientes librerías NuGet:

- [**BouncyCastle**](https://www.bouncycastle.org/): Versión 1.8.9. Librería de criptografía para operaciones de seguridad.
- [**DocumentFormat.OpenXml**](https://github.com/OfficeDev/Open-XML-SDK): Versión 2.5. Para el manejo de archivos de Microsoft Office.
- [**iTextSharp**](https://itextpdf.com/): Versión 5.5.13.3. Librería para la generación de archivos PDF.
- [**SpreadsheetLight**](https://spreadsheetlight.com/): Versión 3.4.1. Utilizada para crear y manipular archivos Excel.

## Requisitos

- **.NET Framework 4.5**
- **Visual Studio 2022** o superior.

## Instalación

1. Clona el repositorio:

    ```bash
    git clone https://github.com/usuario/proyecto-validacion.git
    ```

2. Abre el proyecto en **Visual Studio**.

3. Restaura las dependencias NuGet:

    ```bash
    NuGet > Restore Packages
    ```

4. Compila el proyecto.

## Ejecución

Para ejecutar el proyecto:

1. Carga los archivos que deseas procesar.
2. El sistema validará y procesará la información.
3. Los resultados se mostrarán y se generará un archivo PDF y de log.





