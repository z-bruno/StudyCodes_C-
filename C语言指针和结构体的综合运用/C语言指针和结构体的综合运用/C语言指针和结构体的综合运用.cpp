#include <stdio.h>
#include <malloc.h>

struct weapon {
	char name[20];   //20个字，每个字4位
	int atk;
	int price;
};


int main()
{
	struct weapon weapon1 = { "w1_weapon",100,200 };
	struct weapon weapon2[2] = { {"w2_weapon",50,600},{"w3_weapon",900,35} }; 
	printf("%s  %d\n", weapon1.name, weapon1.price);

	char *c = weapon1.name;
	int *a = &weapon1.atk;
	int *b = &weapon1.price;

	//定义指向weapon类型的指针变量
	struct weapon *w;
	struct weapon *p;
	struct weapon *s;
	//w指向结构体weapom1(类似于实例化?)
	//可通过结构体变量的指针访问weapon1
	w = &weapon1;      
	//动态内存分配，memory allocation，默认类型为(void*)
	s = (struct weapon *)malloc(sizeof(struct weapon));
	printf("%s  %d\n", w->name, w->price);

	//以下三种方式等价
	//w->name weapon1.name (*w).name
	printf("name = %s\n", (*w).name);     
	printf("name = %s\n", weapon1.name);  
	printf("name = %s\n", w->name);

	//没有取地址符，表示指针p指向的是数组元素的第一个元素起始地址！！！
	//如果我们输出p->name，实际它表示的是weapon_2[0].name。
	//如果想访问weapon_2数组中第二个元素的name成员，应该如何操作？
	//我们可以将p进行一个++的操作，则可以访问weapon_2[1].name。
	p = weapon2;  
	printf("%s\n", p->name);
	p++;
	printf("%s\n", p->name);

	//free释放了指针指向的内存但指针变量依然存在
	free(s);
	//赋值NULL释放指针变量
	s = NULL;
	return 0; 
}

