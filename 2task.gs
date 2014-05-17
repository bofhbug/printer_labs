0 842.4 translate 
1 -1 scale

/draw1 {/k exch def /y exch def /x exch def
/kx {k mul x add} def
/ky {k mul y add} def
/kxy {k mul} def
newpath
0 kx 0 ky moveto
30 kx 0 ky lineto
30 kx 5 ky 5 kxy -90 90 arc
30 kx 15 ky 5 kxy -90 90 arc
30 kx 25 ky 5 kxy -90 90 arc
0 kx 30 ky lineto
38 kx 0 ky moveto
38 kx 30 ky lineto
76 kx 30 ky moveto
46 kx 30 ky lineto
46 kx 25 ky 5 kxy 90 270 arc
46 kx 15 ky 5 kxy 90 270 arc
46 kx 5 ky 5 kxy 90 270 arc
76 kx 00 ky lineto
stroke } def
1 1 1 draw1
100 100 3 draw1

showpage