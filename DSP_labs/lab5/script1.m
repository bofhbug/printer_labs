Fs=1600;
N=512;
D0=(1/N)^2/12
for f=[3*Fs/5  Fs/sqrt(8)]
   subplot(2,1,1); 
   t=(0:0.0001:0.006);
   x=cos(2*pi*f*t);
   tn=(0:1/Fs:0.006);
   xn=cos(2*pi*f*tn);
   xround=round(N*xn)/N;
   dx=xround-xn; 
   hist(dx),grid; 
   title(['round f=' int2str(f) 'Hz']);
   D=mean(dx.^2)
   subplot(2,1,2);
   plot(t,x,'k-'),hold on;   
   stem(tn,xround,'r-*'),grid,hold off,pause;
   subplot(2,1,1);
   xfloor=floor(N*xn)/N;
   dx=xfloor-xn;
   hist(dx),grid;
   title(['floor f=' int2str(f) 'Hz']);
   D=mean(dx.^2)
   subplot(2,1,2);
   plot(t,x,'k-'),hold on;   
   stem(tn,xfloor,'r-*'),grid,hold off,pause;
   clf;
end;
