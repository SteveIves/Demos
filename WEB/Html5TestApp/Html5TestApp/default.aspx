<!DOCTYPE HTML>
<html>

<head>
<title>Title of the document</title>
</head>

<body>

    <header>
        <p>This text is in the HEADER tag</p>
    </header>

    <nav>
        <p>This text is in the NAV tag</p>
    </nav>

    <article>
        <p>This text is in the ATRICLE tag</p>

        <p>This video is also in the ATRICLE tag, and produced using the VIDEO tag.</p>
        <video width="640" height="400" controls>
            <source src="~/media/win8video1.mp4" type="video/mp4" />
            <source src="~/media/win8video1.ogg" type="video/ogg" />
            Your browser does not support the video tag.
        </video>

        <p>This audio is also in the ATRICLE tag, and produced using the AUDIO tag.</p>
        <audio controls="controls">
            <source src="~/media/Kalimba.ogg" type="audio/ogg" />
            <source src="~/media/Kalimba.mp3" type="audio/mp3" />
            Your browser does not support the audio element.
        </audio>

        <form action="demo_form.asp" method="get" autocomplete="on">

        <p>E-mail: <input type="email" name="user_email" /></p>

        <p>Homepage URL: <input type="url" name="user_url" /></p>

        <p>Number between 1 and 10: <input type="number" name="a_number" min="1" max="10" /></p>

        <p>Numeric range (1-10): <input type="range" name="a_number_range" min="1" max="10" /></p>

        <p>Date: <input type="date" name="user_date" /></p>

        <p>Color: <input type="color" name="user_color" /></p>

        <p>
            Webpage: <input type="url" list="url_list" name="link" />
            <datalist id="url_list">
            <option label="W3Schools" value="http://www.w3schools.com" />
            <option label="Google" value="http://www.google.com" />
            <option label="Microsoft" value="http://www.microsoft.com" />
            </datalist>
        </p>

        <p></p>

        <p></p>

        <p></p>

        <p></p>

        <p></p>

        <input type="submit" />

        </form>

        <p>An example of CANVAS graphics</p>
        <p>
        <canvas id="myCanvas">
         <script type="text/javascript">
         var canvas=document.getElementById('myCanvas');
         var ctx=canvas.getContext('2d');
         ctx.fillStyle='#FF0000';
         ctx.fillRect(0,0,80,100);
         </script>
         </canvas>
        </p>

        <p>An example of Scalable Vector Graphics graphics</p>
        <p>
            <svg>
                <circle r="50" cx="50" cy="50" fill="red" />
            </svg>
        </p>
    </article>

    <section>
        <p>This text is in a SECTION tag. Not sure if this should be inside the ARTICLE tag?</p>
    </section>

    <footer>
        <p>This text is in the FOOTER tag.</p>
    </footer>

</body>

</html> 



