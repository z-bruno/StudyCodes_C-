#include <stdio.h>
#include <malloc.h>

struct weapon {
	char name[20];   //20���֣�ÿ����4λ
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

	//����ָ��weapon���͵�ָ�����
	struct weapon *w;
	struct weapon *p;
	struct weapon *s;
	//wָ��ṹ��weapom1(������ʵ����?)
	//��ͨ���ṹ�������ָ�����weapon1
	w = &weapon1;      
	//��̬�ڴ���䣬memory allocation��Ĭ������Ϊ(void*)
	s = (struct weapon *)malloc(sizeof(struct weapon));
	printf("%s  %d\n", w->name, w->price);

	//�������ַ�ʽ�ȼ�
	//w->name weapon1.name (*w).name
	printf("name = %s\n", (*w).name);     
	printf("name = %s\n", weapon1.name);  
	printf("name = %s\n", w->name);

	//û��ȡ��ַ������ʾָ��pָ���������Ԫ�صĵ�һ��Ԫ����ʼ��ַ������
	//����������p->name��ʵ������ʾ����weapon_2[0].name��
	//��������weapon_2�����еڶ���Ԫ�ص�name��Ա��Ӧ����β�����
	//���ǿ��Խ�p����һ��++�Ĳ���������Է���weapon_2[1].name��
	p = weapon2;  
	printf("%s\n", p->name);
	p++;
	printf("%s\n", p->name);

	//free�ͷ���ָ��ָ����ڴ浫ָ�������Ȼ����
	free(s);
	//��ֵNULL�ͷ�ָ�����
	s = NULL;
	return 0; 
}

