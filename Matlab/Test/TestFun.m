inL1 = 1;inL2 = 2;inL3 = 3;
% %建立机器人模型
%        theta    d        a        alpha     offset
L1=Link([pi/2     0       0       -pi/2     0     ]); %定义连杆的D-H参数
L2=Link([-pi/2    inL1    0      pi/2        0     ]);
L3=Link([0        0       0       -pi/2     0     ]);
L4=Link([0        inL2   0         pi/2     0     ]);
L5=Link([0        0        0        -pi/2     0     ]);
L6=Link([0        inL3       0        0         0     ]);
robot=SerialLink([L1 L2 L3 L4 L5 L6],'name','ok'); %连接连杆，机器人取名ok
sumLen = inL1 + inL2 + inL3;
%trotz(45),trotz(90),trotz(135),trotz(-45),trotz(-90),trotz(-135),trotz(180)
T = cat(2,trotx(0),trotx(45),trotx(90),trotx(135),trotx(-45),trotx(-90),trotx(-135),trotx(180),...
          troty(45),troty(90),troty(135),troty(-45),troty(-90),troty(-135),...
          trotx(45)*troty(45),trotx(-45)*troty(45),trotx(-45)*troty(-45),trotx(45)*troty(-45),...
          trotx(135)*troty(45),trotx(-135)*troty(45),trotx(-135)*troty(-45),trotx(135)*troty(-45));
% T(:,1:4)
Arr = zeros(1,125);
label = 0;
armLenSqr = power(sumLen,2);
for x = 0:sumLen/2:sumLen
    for y = 0:sumLen/2:sumLen
        for z = -sumLen:sumLen/2:sumLen
            label = label + 1;
            if  armLenSqr < power(x,2)+power(y,2)+power(z,2)
                continue;
            end
            Tpro = transl(x,y,z) * T;
            for n = 1:1:22
                p = robot.ikine(Tpro(:,4*n-3:4*n),50);
                if p~=zeros
                    Arr(label) = Arr(label) + 1;
                end
            end
        end
    end
end