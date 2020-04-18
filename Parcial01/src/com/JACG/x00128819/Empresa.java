package com.JACG.x00128819;

import java.util.ArrayList;

public class Empresa {
    private String nombre;
    private ArrayList<Empleado> planilla;

    public Empresa(String nombre) {
        this.nombre = nombre;
        this.planilla = new ArrayList<>();
    }

    public String getNombre() {
        return nombre;
    }

    public ArrayList<Empleado> getPlanilla() {
        return planilla;
    }

    public void addEmpleado(Empleado nuevo){
        planilla.add(nuevo);
        System.out.println("Se añadió con éxito");
    }
    public void quitEmpleado(String nombreEmpleado){

        boolean encontrado = false;
        for (int i = 0;i<planilla.size();i++){
            if (planilla.get(i).getNombre().equalsIgnoreCase(nombreEmpleado)){
                planilla.remove(i);
                encontrado = true;
                System.out.println("Se borró con éxito");
            }
        }
        if (!encontrado){
            System.out.println("No se encontró\n");
        }
    }
}
