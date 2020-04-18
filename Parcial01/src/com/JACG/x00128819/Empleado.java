package com.JACG.x00128819;

import java.util.ArrayList;

public abstract class Empleado {
    protected String nombre, puesto;
    protected  double salario;
    protected ArrayList<Documento> documentos;

    public Empleado(String nombre, String puesto, double salario) {
        this.nombre = nombre;
        this.puesto = puesto;
        this.salario = salario;
        this.documentos = new ArrayList<>();
    }

    public String getNombre() {
        return nombre;
    }

    public String getPuesto() {
        return puesto;
    }

    public ArrayList<Documento> getDocumentos() {
        return documentos;
    }

    public void addDocumento(Documento nuevoDocumento){
        documentos.add(nuevoDocumento);
        System.out.println("Se añadió con éxito");
    }

    public void removeDocumento(String nombreDocumento){
        boolean encontrado = false;
        for (int i = 0;i<documentos.size();i++){
            if (documentos.get(i).getNombre().equalsIgnoreCase(nombreDocumento)){
                documentos.remove(i);
                encontrado = true;
                System.out.println("Se borró con éxito");
            }
        }
        if (!encontrado){
            System.out.println("No se encontró\n");
        }
    }

    public double getSalario() {
        return salario;
    }

    public void setSalario(double salario) {
        this.salario = salario;
    }
}
