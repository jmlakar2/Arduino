<!DOCTYPE html>
<!--
To change this license header, choose License Headers in Project Properties.
To change this template file, choose Tools | Templates
and open the template in the editor.
-->
<html>
    <head>
        <meta charset="UTF-8">
        <title>REMOTE LIGHT</title>
    </head>
    <body>
        TURN LIGHT ON/OFF: <br>
    <form action="/remote_light/data_change.php" method="get">
        <input type="text" name="on" id="on" value="on" hidden="true"/>
        <input type="submit" value="Turn on"/>
    </form>
       <br>
    <form action="/remote_light/data_change.php" method="get">
        <input type="text" name="off" id="off" value="off" hidden="true"/>
        <input type="submit" value="Turn off"/>
    </form>
    </body>
</html>
