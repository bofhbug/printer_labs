function y = fourier_transform_plotting(func, x1, x2)

number_of_points = 500;
xx = linspace(0, 10.*pi + 1, number_of_points);
yy_magnitude(1) = 0;
yy_phases(1) = 0;
for j=1:number_of_points
    result = integral(@(t)(func(t).*exp(-1i.*xx(j).*t)), x1, x2);
    yy_magnitude(j) = 2.*abs(result);
    yy_phases(j) = pi/2 + angle(result);
    if( yy_phases(j) > pi)
        yy_phases(j) = yy_phases(j) - 2.*pi;
    end
    yy_phases(j) = yy_phases(j).*180./pi;
end

xx_chart(1)=0;
for i=1:5
    xx_chart(i) = 2.*pi.*i;
end

magnitude_chart(1) = 0.2352;
magnitude_chart(2) = 0.4042;
magnitude_chart(3) = 0.1574;
magnitude_chart(4) = 0.1086;
magnitude_chart(5) = 0.0692;

phases_chart(1) = -64.03;
phases_chart(2) = 67.04;
phases_chart(3) = -16.42;
phases_chart(4) = 0.95;
phases_chart(5) = 7.39;


%plot(xx, yy_magnitude);
%grid on;
%hold on;

%for i=1:5
%    stem(xx_chart(i),magnitude_chart(i));
%end

plot(xx, yy_phases);
grid on;
hold on;

for i=1:5
    stem(xx_chart(i),  phases_chart(i));
end

end

