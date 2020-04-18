package com.JACG.x00128819;

import javax.swing.*;
import java.util.ArrayList;
import java.util.Scanner;

public class Main {

    static Scanner in = new Scanner(System.in);

    public static void main(String[] args) {
        ArrayList<Empleado> emp = new ArrayList<>();
        Empresa empre = new Empresa("Coca cola");
        byte op = 0;
        String nombreEm;

        String menu = "1. Agregar empleado\n"+
                "2. Despedir empleado\n"+
                "3. Ver lista de empleados\n"+
                "4. Calcular sueldo\n"+
                "5. Mostrar totales\n"+
                "0. Salir";

        do{
            System.out.println(menu); op = in.nextByte(); in.nextLine();

            switch (op){
                case 1:
                     String nombre, puesto;
                     double salario;

                    System.out.println("Nombre: "); nombre = in.nextLine();
                    System.out.println("Ingrese el nombre del uesto:\n" +
                            "Servicio profesional / Plaza fija  "); puesto = in.nextLine();
                    System.out.println("Salario: "); salario = in.nextDouble(); in.nextLine();
                    if (puesto.equalsIgnoreCase("Servicio profesional")){
                        int mesesContrato;
                        System.out.println("Meses contratados: "); mesesContrato = in.nextInt(); in.nextLine();
                        emp.add(new ServicioProfesional(nombre, puesto, salario, mesesContrato));
                    } else {
                        int extension;
                        System.out.println("Numero de telefono de su oficina: "); extension = in.nextInt(); in.nextLine();
                        emp.add(new PlazaFija(nombre, puesto, salario, extension));
                    }
                    break;

                case 2:
                    String nombreBuscar;
                    System.out.println("Ingrese el nombre del empleado a despedir: "); nombreBuscar = in.nextLine();
                    if (emp.removeIf(borrar-> borrar.getNombre().equals(nombreBuscar))){
                        System.out.println("Empledo despedido");
                    } else {
                        System.out.println("Empleado no encontrado");
                    }
                    break;

                case 3:
                    emp.forEach(lista -> System.out.println(lista.toString()));
                    break;

                case 4:
                   CalculadoraImpuestos.calcularPago();
                    break;

                case 5:
                    CalculadoraImpuestos.mostrarTotales();


            }

        }while (op !=0);
    }
}
