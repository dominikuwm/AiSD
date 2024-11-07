<!DOCTYPE html>
<html lang="pl">
<head>
    <meta charset="UTF-8">
    <meta name="Content-Language" content="pl">
    <meta name="Author" content="Dominik Gutowski">
    <title>Japońskie samochody</title>

    <?php
        // Select CSS file based on the requested page
        $page = $_GET['idp'] ?? 'glowna';
        $cssFiles = [
            'glowna' => 'css/styles.css',
            'kontakt' => 'css/kontakt.css',
            'historia' => 'css/historiacss.css',
            'popmar' => 'css/popmar.css',
            'motorsport' => 'css/motorsport.css',
            'samelek' => 'css/samelek.css',
            'filmy' => 'css/stylecwiczenie3.css'
        ];

        // Use the default stylesheet if page is not specified
        $cssFile = $cssFiles[$page] ?? 'css/styles.css';

        echo '<link rel="stylesheet" href="' . $cssFile . '">';
    ?>
</head>
<body>
    <!-- Header Image -->
    <img src="obrazki/naStroneGlowna.jpg" alt="Japońskie samochody" class="header-image">

    <!-- Navigation -->
    <nav>
        <ul>
            <li><a href="index.php?idp=glowna">Strona Główna</a></li>
            <li><a href="index.php?idp=kontakt">Kontakt</a></li>
            <li><a href="index.php?idp=historia">Historia japońskich samochodów</a></li>
            <li><a href="index.php?idp=popmar">Najpopularniejsze marki</a></li>
            <li><a href="index.php?idp=motorsport">Motorsport i tuning</a></li>
            <li><a href="index.php?idp=samelek">Samochody elektryczne i hybrydowe</a></li>
            <li><a href="index.php?idp=filmy">Filmy</a></li>
        </ul>
    </nav>

    <!-- Main Content Area -->
    <main>
        <?php
            error_reporting(E_ALL ^ E_NOTICE ^ E_WARNING);

            // Define available content pages
            $pages = [
                'glowna' => 'html/glowna.html',
                'kontakt' => 'html/kontakt.html',
                'historia' => 'html/historia.html',
                'popmar' => 'html/popmar.html',
                'motorsport' => 'html/motorsport.html',
                'samelek' => 'html/samelek.html',
                'filmy' => 'html/filmy.html'
            ];

            // Determine which content file to load
            $strona = $pages[$page] ?? 'html/glowna.html';

            // Include the content file if it exists
            if (file_exists($strona)) {
                include($strona);
            } else {
                echo 'Page not found.';
            }
        ?>
    </main>

    <!-- Footer Information -->
    <footer>
        <?php
            $nr_indeksu = '169243';
            $nrGrupy = '2';
            echo 'Autor: Dominik Gutowski, Nr Indeksu: '.$nr_indeksu.', Grupa: '.$nrGrupy;
        ?>
    </footer>
</body>
</html>
