(function(){if("undefined"!==typeof window){var g=window.sfx;var n=window.cfx}else g=require("./jchartfx.system.js"),n=g.cfx;n.pyramidVersion="7.6.7367.23301";var F=function d(){d._ic();this.h=null;this.e=this.g=!1;this.d=0;this.f=this.a=!1;this.b=5};n.Pyramid=F;F.prototype={getConic:function(){return this.g},setConic:function(d){this.g=d;this.c()},getDistributeHeight:function(){return this.e},setDistributeHeight:function(d){this.e=d;this.c()},getFaces:function(){return 0==this.d?4:this.d},setFaces:function(d){this.d=
g.a.o(d,3);this.c()},getInverted:function(){return this.a},setInverted:function(d){this.a=d;this.c()},getSeparation:function(){return this.b},setSeparation:function(d){this.b=d;this.c()},getShadow2D:function(){return this.f},setShadow2D:function(d){this.f=d;this.c()},ic5:function(d,c,a,b){switch(c){case 11:return this.i(a);case 12:return this.a;case 18:return 1}return null},ic6:function(d){return 1},ic7:function(d){return 142737665},ic8:function(d,c,a){d.a=1;d.b=0;d=a.g(256);c=new n.bj;a.bK(c);d&&
(a.bn=!0);var b=a.a.d.c,f=a.l._nc();f.w-=a.a.q;f.y+=a.a.q;f.h-=a.a.q;var h=f.h,k=f.w,u=(h-this.b*(b-1))*f.w/2,r=h/k,l=983040|a.b.m;a.g(256)||(l|=134217728);0!=this.b&&(l|=3145728);if(this.a){var e=-h;var m=-1;var q=f.c();var z=f.y}else e=h,m=1,q=f.y,z=f.c();var t=new n.a_,p=new n.a_;t.b=f.x;t.a=z+m*this.b;t.c=0;p.b=f.g();p.a=q-m*this.b;p.c=a.a.e;z=~~((f.g()+f.x)/2);this.a&&90<a.f.ib$()||!this.a&&90>=a.f.ib$()?(a.y=-1,a.o=b-1,a.e=a.o,a.q=0):(a.y=1,a.o=0,a.e=0,a.q=b-1);for(var C=d?this.d:4,v,y=0;y<
b;y++){a.ag();if(0!=a.K&&!n.df.i(a.K)){0>a.y?(this.e?v=h-a.U/a.R*h:(v=u-a.U*u/a.R,v=g.a.v(g.a.d(2*v*r))),p.a=t.a-m*this.b,t.a=q+m*v):(this.e?v=g.a.d(a.w)/a.R*h:(v=a.U*u/a.R,v=g.a.v(g.a.d(2*v*r))),t.a=p.a+m*this.b,p.a=q+m*v);v=this.a?f.y-p.a:f.c()-p.a;var w=0;d||this.f||(w|=32);a.g(33554432)&&(w|=1);a.aK(a.d,a.e,!1);a.V(!0);a.aA(a.d,a.e);var A=l;y==b-1&&(A|=3145728);this.g?a.f.icd(a.c,t,p,a.x,a.v,null,A,w,e,v,C):a.f.ics(a.c,t,p,a.x,a.v,null,A,w,e,v,C);v=a.K/a.R;a.b.a.a&&this.j(a,c,k,h,t,p,z,q,v)}a.af(0,
1)}a.al-=b-1;a.e=a.q},ieU:function(d,c){d=new g._p1(this.d);c.ie9(d,"Faces",0);this.d=d.a;d.a=this.f;c.ifa(d,"Shadow2D",!1);this.f=d.a;d.a=this.g;c.ifa(d,"Conic",!1);this.g=d.a;d.a=this.a;c.ifa(d,"Inverted",!1);this.a=d.a;d.a=this.b;c.ie9(d,"Separation",5);this.b=d.a;9<=c.ieY()&&(d.a=this.e,c.ifa(d,"DistributeHeight",!1),this.e=d.a)},ifg:function(d){this.h=d},j:function(d,c,a,b,f,h,k,u,r){var l=new n.a_,e=d.b.a.f,m=d.b.a.c;d.g(256)&&1==e&&(e=0);switch(m){case 0:l.a=this.a?h.a:f.a;break;case 2:l.a=
this.a?f.a:h.a;break;default:l.a=~~((f.a+h.a)/2)}1!=e?(a=n.bQ.a(l.a-u,~~(a/2),b),l.b=(this.a?0==e:2==e)?k-a:k+a,l.b=2==e?l.b-~~(d.aU/2):l.b+~~(d.aU/2)):l.b=k;l.c=~~(d.a.e/2);k=d.f.icq(l,0);c=d.bs(c,r);c=d.bb(d.j,c);r=0;d.b.a.k&&(r=4096);e=(new n.cM)._02cM(d.b.a.b,e,m,r);d.bc(e,c,k,0,g.g.b)},c:function(){null!=this.h&&this.h.iai(16777248)},i:function(d){d=d.a;0==d.c&&(d.c=17);0==d.d&&(d.d=1);return null}};F._dt("Pyramid",g.SA,0,n.ic4,n.ieT,n.iff);var B=function c(){c._ic();this.w=this.y=!1;this.v=
0;this.r=!1;this._0_2()};n.VectorPyramid=B;B.prototype={_0_2:function(){this._bc._0eU.call(this);this.u=-1;this.x=5;return this},getConic:function(){return this.y},setConic:function(c){this.y=c;this.t()},getDistributeHeight:function(){return this.w},setDistributeHeight:function(c){this.w=c;this.t()},getFaces:function(){return 0==this.v?4:this.v},setFaces:function(c){this.v=g.a.o(c,3);this.t()},n:function(){return"Pyramid"},getInverted:function(){return this.r},setInverted:function(c){this.r=c;this.t()},
getSeparation:function(){return-1!=this.u?this.u:this.x},setSeparation:function(c){this.u=c;this.t()},ic5:function(c,a,b,f){switch(a){case 18:return 1;case 12:return this.r;case 11:return this.B(b)}return null},ic6:function(c){return 1},ic7:function(c){return 142737665},ic8:function(c,a,b){c.a=1;c.b=0;var f=b.g(256);c=!1;this.a.u()&&(this.e(),this.a.E(null,null),c=!0);a=new n.bj;b.bK(a);f&&(b.bn=!0);var h=b.a.d.c,k=b.l._nc();k.w-=b.a.q;k.y+=b.a.q;k.h-=b.a.q;var u=k.h,r=k.w,l=this.getSeparation(),
e=(u-l*(h-1))*k.w/2,m=u/r,q=983040|b.b.m;if(f)var z=!0;else q|=134217728,z=!1;0!=l&&(q|=3145728);if(this.r){var t=-u;var p=-1;var C=k.c();var v=k.y}else t=u,p=1,C=k.y,v=k.c();var y=new n.a_,w=new n.a_;y.b=k.x;y.a=v+p*l;y.c=0;w.b=k.g();w.a=C-p*l;w.c=b.a.e;v=~~((k.g()+k.x)/2);this.r&&90<b.f.ib$()||!this.r&&90>=b.f.ib$()?(b.y=-1,b.o=h-1,b.e=b.o,b.q=0):(b.y=1,b.o=0,b.e=0,b.q=h-1);f=f?this.v:4;var A=0,D=b.R,B=b.ae;if(B){for(var E=D=0;E<h;E++){b.aK(b.d,E,!1);var x=b.Z.getItem(b.d,E)*b.a3;D+=x}if(0==D)return}for(E=
0;E<h;E++){b.ag();if(B){if(0==b.a3){b.af(0,1);continue}b.K*=b.a3;A+=b.K}else A=b.U;if(0!=b.K&&1E108!=b.K){0>b.y?(this.w?x=u-A/D*u:(x=e-A*e/D,x=g.a.v(g.a.d(2*x*m))),w.a=y.a-p*l,y.a=C+p*x):(this.w?x=A/D*u:(x=A*e/D,x=g.a.v(g.a.d(2*x*m))),y.a=w.a+p*l,w.a=C+p*x);x=this.r?k.y-w.a:k.c()-w.a;var G=0;b.g(33554432)&&(G|=1);b.aK(b.d,b.e,!1);b.V(!0);b.aA(b.d,b.e);var F=q;E==h-1&&(F|=3145728);z?this.y?b.f.icd(b.c,y,w,b.x,b.v,null,F,G,t,x,f):b.f.ics(b.c,y,w,b.x,b.v,null,F,G,t,x,f):this.E(b.c,y,w,G,t,x,b);x=b.K/
D;b.b.a.a&&this.F(b,a,r,u,y,w,v,C,x)}b.af(0,1)}b.al-=h-1;b.e=b.q;c&&this.a.H();this.a._dispose1(!1)},l:function(){this.x=5;var c=this.a.k;null!=c&&(c=c.a("cfxDefSeparation"),c=g.TD(c,g.b),null!=c&&(this.x=g.u.e(c)))},F:function(c,a,b,f,h,k,g,r,l){var e=new n.a_,m=c.b.a.f,q=c.b.a.c;c.g(256)&&(m=0);switch(q){case 0:e.a=this.r?k.a:h.a;break;case 2:e.a=this.r?h.a:k.a;break;default:e.a=~~((h.a+k.a)/2)}1!=m?(b=n.bQ.a(e.a-r,~~(b/2),f),e.b=(this.r?0==m:2==m)?g-b:g+b,e.b=2==m?e.b-~~(c.aU/2):e.b+~~(c.aU/2)):
e.b=g;e.c=~~(c.a.e/2);g=c.f.icq(e,0);a=c.bs(a,l);a=c.bb(c.j,a);c.bQ(a,g,m,q,!0,0)},E:function(c,a,b,f,h,k,u){c=n.a_._ca(4);f=n.a_._ca(4);n.a_._ca(4);var r=~~((a.b+b.b)/2);var l=~~((a.c+b.c)/2);var e=b.a-a.a;var m=b.b-a.b;var q=b.c-a.c;m=~~(m/2);q=~~(q/2);var z=n.bQ.a(k,m,h);var t=n.bQ.a(k,q,h);var p=new g._p1(void 0);B.A(p,4,r,b.a,l,m-z,q-t,c,-1,!0);z=n.bQ.a(k+e,m,h);t=n.bQ.a(k+e,q,h);B.A(p,4,r,a.a,l,m-z,q-t,f,-1,!0);h=g.e._ca(4);h[0].x=c[1].b;h[0].y=b.a;h[1].x=c[3].b;h[1].y=b.a;h[2].y=a.a;h[2].x=
f[3].b;h[3].x=f[1].b;h[3].y=a.a;if(b.a!=a.a){k=g.d.b;c=null;f=this.a.id().L.A;r=f.length;for(l=0;l<r;l++)switch(e=f[l],e.c){case "P":case "PointsPolygon":e.sa(h);break;case "X":e.sa(g.a.p(a.b,b.b));break;case "W":e.sa(g.a.d(b.b-a.b));break;case "Y":e.sa(g.a.p(a.a,b.a));break;case "H":e.sa(g.a.d(b.a-a.a));break;case "G":case "Geometry":null==c&&(c=new g.aB,c.z(h));e.sa(c);break;default:this.a.m(e,u,this,k)}this.c(u,this.a,g.d.b)}},t:function(){null!=this.b&&this.b.iai(16777248)},k:function(c,a){c=
new g._p1(this.v);a.ie9(c,"Faces",0);this.v=c.a;c.a=this.y;a.ifa(c,"Conic",!1);this.y=c.a;c.a=this.r;a.ifa(c,"Inverted",!1);this.r=c.a;c.a=this.u;a.ie9(c,"Separation",-1);this.u=c.a;c.a=this.w;a.ifa(c,"DistributeHeight",!1);this.w=c.a},B:function(c){c=c.a;0==c.c&&(c.c=17);0==c.d&&(c.d=1);return null}};B.A=function(c,a,b,f,h,k,n,r,l,e){var m;a=g.a.o(g.a.d(a),2);a=g.a.p(a,4);var q=6.28318530717959/a;var u=g.a.u(q);var t=g.a.i(q);e=1;for(l=m=0;l<a;l++){r[l].a=f;r[l].b=b+g.a.k(k*m+.5);r[l].c=h+g.a.k(n*
e+.5);var p=e*t+m*u;m=m*t-e*u;e=p}c.a=q;return a};B._dt("VectorPyramid",n.eU,0,n.ic4);void 0!==n.UserInterface&&n.UserInterface.prototype.galleryMap["1"].push("14,Pyramid")})();
