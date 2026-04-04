using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day03
{
    class BSTree
    {
        private BSTNode root;

        public BSTree()
        {
            root = null;
        }

        //  Insert 
        public void Insert(Employee emp)
        {
            root = InsertRecursive(root, emp);
        }

        private BSTNode InsertRecursive(BSTNode node, Employee emp)
        {
            if (node == null)
                return new BSTNode(emp);

            if (emp.Salary < node.data.Salary)
                node.left = InsertRecursive(node.left, emp);
            else if (emp.Salary > node.data.Salary)
                node.right = InsertRecursive(node.right, emp);
            else //  ==
            {
                if (!emp.Equals(node.data))
                    node.right = InsertRecursive(node.right, emp);

                // == , no add
            }

            return node;
        }




        //
        public void InsertIterative(Employee emp)
        {
            BSTNode newNode = new BSTNode(emp);

            if (root == null)
            {
                root = newNode;
                return;
            }

            BSTNode current = root;
            BSTNode parent = null;

            while (current != null)
            {
                parent = current;

                if (emp.Salary < current.data.Salary)
                    current = current.left;

                else
                    current = current.right;
            }

            if (emp.Salary < parent.data.Salary)
                parent.left = newNode;
            else
                parent.right = newNode;
        }



       
        // ] Search 
        public BSTNode Search(double salary)
        {
            BSTNode current = root;

            while (current != null)
            {
                if (salary == current.data.Salary)
                    return current;
                else if (salary < current.data.Salary)
                    current = current.left;
                else
                    current = current.right;
            }

            return null; 
        }

        //  In-Order 
        public void InOrderTraversal()
        {
            InOrderRecursive(root);
        }

        private void InOrderRecursive(BSTNode node)
        {
            if (node == null)
                return;

            InOrderRecursive(node.left);
            Console.WriteLine(node.data);
            InOrderRecursive(node.right);
        }

        // Max 
        public Employee GetMaxSalary()
        {
            if (root == null) return null;

            BSTNode current = root;
            while (current.right != null)
                current = current.right;

            return current.data;
        }

        //  Min 
        public Employee GetMinSalary()
        {
            if (root == null) return null;

            BSTNode current = root;
            while (current.left != null)
                current = current.left;

            return current.data;
        }
    }
}
